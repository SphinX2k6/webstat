using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020032C1 RID: 12993
public class PbPreloadAssetElement : AssetElement
{
	// Token: 0x0601B3C0 RID: 111552 RVA: 0x0082ECAD File Offset: 0x0082CEAD
	public PbPreloadAssetElement(int pbDataId) : base(null)
	{
		this.PbDataId = new int?(pbDataId);
	}

	// Token: 0x1700251D RID: 9501
	// (get) Token: 0x0601B3C1 RID: 111553 RVA: 0x0082ECC2 File Offset: 0x0082CEC2
	public int? GetPbDataId
	{
		get
		{
			return this.PbDataId;
		}
	}

	// Token: 0x1700251E RID: 9502
	// (get) Token: 0x0601B3C2 RID: 111554 RVA: 0x0082ECCA File Offset: 0x0082CECA
	private int HolderEntityId
	{
		get
		{
			return -this.PbDataId.GetValueOrDefault();
		}
	}

	// Token: 0x0601B3C3 RID: 111555 RVA: 0x0082ECD8 File Offset: 0x0082CED8
	[NullableContext(1)]
	public override bool AddObject(string path, UObject @object)
	{
		if (!base.AddObject(path, @object))
		{
			return false;
		}
		ModelBase<PreloadModelNew>.Instance.HoldPreloadObject.AddEntityAsset(this.HolderEntityId, @object);
		return true;
	}

	// Token: 0x0400DDFF RID: 56831
	public int? PbDataId;
}
