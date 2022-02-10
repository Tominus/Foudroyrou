
public interface IManagedItem<TID>
{
	#region Field/Properties
	TID ID { get; }
	public bool IsValid { get; }
	#endregion Field/Properties
	#region Methods
	/// <summary>
	/// call this function on start and set all needed variable
	/// </summary>
	abstract void InitItem();
	/// <summary>
	/// call this function on destroy and null all needed variable
	/// </summary>
	abstract void DestroyItem();
	abstract void Enable();
	abstract void Disable();
	abstract void SetID(TID _id);
	#endregion Methods
}
