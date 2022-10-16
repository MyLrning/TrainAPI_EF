using EFNewAPI.Models;
using EFNewAPI.Settings;

namespace EFNewAPI.Services;

public class CategoryService : ICategoryService
{
    private readonly TasksContext _context;

    public CategoryService(TasksContext context)
    {
        this._context = context;
    }

    public IEnumerable<Category> Get()
    {
        return _context.Categories.ToList();
    }

    public async Task Add(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, Category category)
    {
        var categoryToUpdate = await _context.Categories.FindAsync(id);

        if (categoryToUpdate == null) return;

        categoryToUpdate.Name = category.Name;
        categoryToUpdate.Description = category.Description;
        categoryToUpdate.Weight = category.Weight;
        
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var categoryToDelete = await _context.Categories.FindAsync(id);

        if (categoryToDelete == null) return;

        _context.Categories.Remove(categoryToDelete);
        
        await _context.SaveChangesAsync();
    }
}

public interface ICategoryService
{
    IEnumerable<Category> Get();
    Task Add(Category category);
    Task Update(int id, Category category);
    Task Delete(int id);
}
