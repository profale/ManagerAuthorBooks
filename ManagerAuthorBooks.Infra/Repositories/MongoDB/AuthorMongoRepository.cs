using ManagerAuthorBooks.Domain.Entities;
using ManagerAuthorBooks.Domain.Repositories.MongoDB;
using ManagerAuthorBooks.Infra.Context;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAuthorBooks.Infra.Repositories.MongoDB
{
    public class AuthorMongoRepository : IAuthorMongoRepository
    {
        //atributo
        private readonly MongoDBContext _mongoDBContext;
        private IClientSessionHandle _clientSession;

        public AuthorMongoRepository(MongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
        }

        public bool Add(Author author)
        {
            _clientSession.StartTransaction();
            try
            {
                _mongoDBContext.Authors.InsertOne(author);
                _clientSession.CommitTransaction();
                return true;
            }
            catch (Exception)
            {
                _clientSession.AbortTransaction();
                return false;
            }
        }
        public async Task<bool> AddAsync(Author author)
        {
            _clientSession.StartTransaction();
            try
            {
                await _mongoDBContext.Authors.InsertOneAsync(author);
                await _clientSession.CommitTransactionAsync();
                return true;
            }
            catch (Exception)
            {
                await _clientSession.AbortTransactionAsync();
                return false;
            }
        }
        public bool Update(Author author)
        {
            _clientSession.StartTransaction();
            try
            {
                var filter = Builders<Author>.Filter.Eq(a => a.Id, author.Id);
                _mongoDBContext.Authors.ReplaceOne(filter, author);
                return true;

            }
            catch (Exception)
            {
                _clientSession.AbortTransaction();
                return false;
            }
        }
        public async Task<bool> UpdateAsync(Author author)
        {
            _clientSession.StartTransaction();
            try
            {
                var filter = Builders<Author>.Filter.Eq(a => a.Id, author.Id);
                await _mongoDBContext.Authors.ReplaceOneAsync(filter, author);
                await _clientSession.CommitTransactionAsync();
                return true;
            }
            catch (Exception)
            {
                await _clientSession.AbortTransactionAsync();
                return false;
            }
        }
        public bool Remove(Author author)
        {
            _clientSession.StartTransaction();
            try
            {
                var filter = Builders<Author>.Filter.Eq(a => a.Id, author.Id);
                _mongoDBContext.Authors.DeleteOne(filter);
                _clientSession.CommitTransaction();
                return true;
            }
            catch (Exception)
            {
                _clientSession.AbortTransaction();
                return false;
            }
        }
        public async Task<bool> RemoveAsync(Author author)
        {
            _clientSession.StartTransaction();
            try
            {
                var filter = Builders<Author>.Filter.Eq(a => a.Id, author.Id);
                await _mongoDBContext.Authors.DeleteOneAsync(filter);
                await _clientSession.CommitTransactionAsync();
                return true;
            }
            catch (Exception)
            {
                _clientSession.AbortTransaction();
                return false;
            }
        }
        public List<Author> GetAll()
        {
            var filter = Builders<Author>.Filter.Where(a => true);
            return _mongoDBContext.Authors.Find(filter).ToList();
        }
        public async Task<List<Author>> GetAllAsync()
        {
            var filter = Builders<Author>.Filter.Where(a => true);
            var authors = await _mongoDBContext.Authors.FindAsync(filter);
            return authors.ToList();
        }
        public Author Get(Guid id)
        {
            var filter = Builders<Author>.Filter.Where(a => a.Id == id);
            return _mongoDBContext.Authors.Find(filter).FirstOrDefault();
        }
        public async Task<Author> GetAsync(Guid id)
        {
            var filter = Builders<Author>.Filter.Where(a => a.Id == id);
            return (Author) await _mongoDBContext.Authors.FindAsync(filter);
        }
    }
}
