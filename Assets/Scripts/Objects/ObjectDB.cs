using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDB {

	private static ObjectDB instance;

	private IDictionary<ObjectType, GameObject> db = new Dictionary<ObjectType, GameObject>();

	private ObjectDB() {}

	public static ObjectDB Instance
	{
	   get {
	     if (instance == null){
	        instance = new ObjectDB();
	     }
	     return instance;
	   }
	}

	public void RegisterItem(ObjectType type, GameObject go) {
		db.Add(type, go);
	}

	public bool UnregisterItem(ObjectType type) {
		return db.Remove(type);
	}

}
