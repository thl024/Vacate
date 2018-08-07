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

	public void RegisterObject(ObjectType type, GameObject go) {
		db.Add(type, go);
	}

	public GameObject GetObject(ObjectType type) {
		if (db.ContainsKey(type)) {
			return db[type];
		}
		return null;
	}

	public bool UnregisterObject(ObjectType type) {
		return db.Remove(type);
	}

}
