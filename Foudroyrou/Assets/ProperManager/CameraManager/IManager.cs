using System.Collections.Generic;
using UnityEngine;

public interface IManager<TID,TItem> where TItem : IManagedItem<TID> 
{
	#region Field/Properties
	Dictionary<TID, TItem> Items { get; }
	#endregion Field/Properties
	#region Methods
	void Add(TItem _item);
	void Remove(TItem _item);
	void Remove(TID _id);
	void Enable(TItem _item);
	void Enable(TID _id);
	void Disable(TItem _item);
	void Disable(TID _id);
	TItem Get(TID _id);
	bool Exist(TID _id);
	bool Exist(TItem _item);
	#endregion Methods
}
