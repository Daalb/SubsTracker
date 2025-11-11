using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubsTracker.Models.ViewModels;
using SubsTracker.Services;

namespace SubsTracker.Controllers;
public class SubscriptionController(
    ISubscriptionService subscriptionService) : Controller
{
    // GET: Subscription
    public async Task<IActionResult> Index()
    {
        return View(await subscriptionService.GetAllSubscriptionsAsync());
    }

    // GET: Subscription/Details/5
    public async Task<IActionResult> Details(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var subscription = await subscriptionService.GetSubscriptionByIdAsync(id);
        if (subscription == null)
        {
            return NotFound();
        }

        return View(subscription);
    }

    // GET: Subscription/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Subscription/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SubscriptionViewModel subscription)
    {
        if (ModelState.IsValid)
        {
            await subscriptionService.CreateSubscriptionAsync(subscription);
            return RedirectToAction(nameof(Index));
        }
        return View(subscription);
    }

    // GET: Subscription/Edit/5
    public async Task<IActionResult> Edit(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var subscriptionEntity = await subscriptionService.GetSubscriptionByIdAsync(id);
        if (subscriptionEntity == null)
        {
            return NotFound();
        }
        return View(subscriptionEntity);
    }

    // POST: Subscription/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, SubscriptionViewModel subscription)
    {
        if (id != subscription.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await subscriptionService.UpdateSubscriptionAsync(subscription);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await subscriptionService.SubscriptionEntityExists(subscription.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(subscription);
    }

    // GET: Subscription/Delete/5
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var subscription = await subscriptionService.GetSubscriptionByIdAsync(id);
        if (subscription == null)
        {
            return NotFound();
        }

        return View(subscription);
    }

    // POST: Subscription/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var subscription = await subscriptionService.GetSubscriptionByIdAsync(id);
        if (subscription != null)
        {
            await subscriptionService.DeleteSubscriptionAsync(id);
        }

        return RedirectToAction(nameof(Index));
    }
}
