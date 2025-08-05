/*
 * Eternal Quest Program
 * Developed using Polymorphism: Goal is abstract base class with polymorphic methods.
 * Derived classes override RecordEvent and others to provide specific behavior.
 *
 * Creativity and Exceeding Core Requirements:
 * - Implemented reflection in GoalManager to restore private member variables (_isComplete, _amountCompleted) when loading goals.
 * - Added robust input validation to prevent crashes.
 * - Implemented bonus points logic in ChecklistGoal to reward users upon completion.
 * - Provided clear menu-driven user interface.
 * - Each class is in its own file with proper naming conventions and code styling.
 * - Error handling added for file I/O operations.
 */

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
