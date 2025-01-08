namespace Friendly.Services;

public class FriendService {
    private static List<Friend> friends = new List<Friend>{
        new Friend{FriendId=Guid.NewGuid(), FriendName="Friend1", Place="Place1"},
        new Friend{FriendId=Guid.NewGuid(), FriendName="Friend2", Place="Place2"},
        new Friend{FriendId=Guid.NewGuid(), FriendName="Friend3", Place="Place3"},
        new Friend{FriendId=Guid.NewGuid(), FriendName="Friend4", Place="Place4"},
        new Friend{FriendId=Guid.NewGuid(), FriendName="Friend5", Place="Place5"},
    };

    public static List<Friend> GetFriendList(){
        return friends;
    }

    public static bool AddFriend(Friend newFriend){
        foreach(var friend in friends){
            if(friend.Equals(newFriend)){
                return false;
            }
        }
        friends.Add(newFriend);
        return true;
    }

    public static bool UpdateFriend(Friend newFriend){

        foreach(var friend in friends){
            if(friend.FriendId == newFriend.FriendId){
                friend.FriendName = newFriend.FriendName;
                friend.Place = newFriend.Place;
                return true;
            }
        }
        return false;
    }

    public static bool RemoveFriend(Guid id){
        Friend? friendToRemove = null;
        foreach(var friend in friends){
            if(friend.FriendId == id){
                friendToRemove = friend;
            }
        }
        if(friendToRemove != null){
            friends.Remove(friendToRemove);
            return true;
        }
        return false;
    }

    public static Friend? FindFriend(Guid id){
        foreach(var friend in friends){
            if(friend.FriendId == id){
                return friend;
            }
        }
        return null;
    }
}