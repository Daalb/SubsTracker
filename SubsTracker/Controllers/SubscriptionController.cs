using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubsTracker.Database;
using SubsTracker.Models.Entities;
using SubsTracker.Models.ViewModels;
using SubsTracker.Services;

namespace SubsTracker.Controllers;
public class SubscriptionController(
    SubsTrackerContext context,
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

        var subscriptionEntity = await context.Subscriptions
            .FirstOrDefaultAsync(m => m.Id == id);
        if (subscriptionEntity == null)
        {
            return NotFound();
        }

        return View(subscriptionEntity);
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

        var subscriptionEntity = await context.Subscriptions.FindAsync(id);
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
    public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Description,Value,Currency,Category,PaymentDate,Frecuency")] SubscriptionEntity subscriptionEntity)
    {
        if (id != subscriptionEntity.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                context.Update(subscriptionEntity);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionEntityExists(subscriptionEntity.Id))
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
        return View(subscriptionEntity);
    }

    // GET: Subscription/Delete/5
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var subscriptionEntity = await context.Subscriptions
            .FirstOrDefaultAsync(m => m.Id == id);
        if (subscriptionEntity == null)
        {
            return NotFound();
        }

        return View(subscriptionEntity);
    }

    // POST: Subscription/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var subscriptionEntity = await context.Subscriptions.FindAsync(id);
        if (subscriptionEntity != null)
        {
            context.Subscriptions.Remove(subscriptionEntity);
        }

        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool SubscriptionEntityExists(string id)
    {
        return context.Subscriptions.Any(e => e.Id == id);
    }
}
