using ParliParrotCore.Persistence.Firebase.Database;

namespace WebAPI.Models
{
    public interface IFirebaseDB
    {
        FirebaseResponse Put(string jsonData);
        FirebaseDB Node(string node);
    }
}
