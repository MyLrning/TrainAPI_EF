using EFNewAPI.Models;
using EFNewAPI.Settings;

namespace EFNewAPI.Services;

public class TaskService : ITaskService
{
    private readonly TasksContext _context;

    public TaskService(TasksContext context)
    {
        _context = context;
    }

    public IEnumerable<Duty> Get()
    {
        return _context.Tasks;
    }

    public async Task Add(Duty task)
    {
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, Duty task)
    {
        var taskToUpdate = await _context.Tasks.FindAsync(id);

        if (taskToUpdate == null) return;

        taskToUpdate.Title = task.Title;
        taskToUpdate.Description = task.Description;
        taskToUpdate.CategoryId = task.CategoryId;
        taskToUpdate.Deadline = task.Deadline;
        taskToUpdate.Priority = task.Priority;

        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var taskToDelete = await _context.Tasks.FindAsync(id);

        if (taskToDelete == null) return;

        _context.Tasks.Remove(taskToDelete);

        await _context.SaveChangesAsync();
    }

}

public interface ITaskService
{
    IEnumerable<Duty> Get();
    Task Add(Duty task);
    Task Update(int id, Duty task);
    Task Delete(int id);
}

