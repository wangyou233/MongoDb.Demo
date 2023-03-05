using MgDbDemo.Configs;
using MgDbDemo.Entities;
using MongoDB.Driver;

namespace MgDbDemo.Services.Impl;

public class BookService: IBookService
{
    private readonly IMongoCollection<Book> _books;

    public BookService(IBookStoreDatabaseSettings settings)
    {
        var mongoClient = new MongoClient(settings.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(settings.DatabaseName);
        _books = mongoDatabase.GetCollection<Book>(settings.BooksCollectionName);
    }

    public Book Create(Book book)
    {
        _books.InsertOne(book);
        return book;
    }

    public async Task<Book> CreateAsync(Book book)
    {
        await _books.InsertOneAsync(book);
        return book;
    }

    public IList<Book> Get()
    {
        return _books.Find(book => true).ToList();
    }

    public async Task<IList<Book>> GetAsync()
    {
        return await _books.Find(book => true).ToListAsync();
    }

    public Book Get(string id)
    {
        return _books.Find(book => book.Id == id).FirstOrDefault();
    }

    public async Task<Book> GetAsync(string id)
    {
        return await _books.Find(book => book.Id == id).FirstOrDefaultAsync();
    }

    public void Remove(string id)
    {
        _books.DeleteOne(book => book.Id == id);
    }

    public async Task RemoveAsync(string id)
    {
        await _books.DeleteOneAsync(book => book.Id == id);
    }

    public void Update(string id, Book bookIn)
    {
        _books.ReplaceOne(book => book.Id == id, bookIn);
    }

    public async Task UpdateAsync(string id, Book bookIn)
    {
        await _books.ReplaceOneAsync(book => book.Id == id, bookIn);
    }
}