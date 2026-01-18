using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities (low, high, medium).
    // Expected Result: Dequeue returns the value with the highest priority first.
    // Defect(s) Found: does not consider the last item in the queue when searching for the highest priority
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low priority", 1);
        priorityQueue.Enqueue("medium priority", 2);
        priorityQueue.Enqueue("high priority", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("high priority", result);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the SAME highest priority.
    // Expected Result: Dequeue returns the FIRST item enqueued among the tied highest priorities (FIFO tie-break).
    // Defect(s) Found: When multiple items share the highest priority, Dequeue() returns the most recently enqueued one (LIFO behavior)
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("medium priority", 5);
        priorityQueue.Enqueue("first high priority", 10);
        priorityQueue.Enqueue("second high priority", 10);
        priorityQueue.Enqueue("low priority", 1);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("first high priority", result);
    }

    [TestMethod]
    // Scenario: Dequeue from an empty priority queue.
    // Expected Result: An InvalidOperationException is thrown.
    // Defect(s) Found: Passed
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected InvalidOperationException was not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }

    [TestMethod]
    // Scenario: Enqueue a single item and then dequeue it.
    // Expected Result: The dequeued item matches the enqueued item.
    // Defect(s) Found: Passed
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("only item", 42);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("only item", result);
    }

    [TestMethod]
    // Scenario: Highest priority item is at the LAST position in the queue.
    // Expected Result: Dequeue returns that last item’s value.
    // Defect(s) Found: Dequeue() fails when the highest-priority item is the last element
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 1);
        priorityQueue.Enqueue("second", 2);
        priorityQueue.Enqueue("last", 5);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("last", result);
    }

    [TestMethod]
    // Scenario: After a Dequeue, the removed item should no longer be in the queue.
    // Expected Result: After removing the highest priority item, the next Dequeue returns the next-highest.
    // Defect(s) Found: Dequeue() does not remove the selected highest-priority item from the queue
    public void TestPriorityQueue_6()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low priority", 1);
        priorityQueue.Enqueue("high priority", 3);
        priorityQueue.Enqueue("medium priority", 2);

        var firstDequeue = priorityQueue.Dequeue();
        Assert.AreEqual("high priority", firstDequeue);

        var secondDequeue = priorityQueue.Dequeue();
        Assert.AreEqual("medium priority", secondDequeue);
    }
}