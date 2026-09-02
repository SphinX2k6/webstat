using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x0200149C RID: 5276
[NullableContext(1)]
[Nullable(0)]
public class PinballWeaponData
{
	// Token: 0x060093B5 RID: 37813 RVA: 0x0026FE38 File Offset: 0x0026E038
	public void Phrase(PinballWeapon info)
	{
		this.Id = info.ConfigId;
		this.IncId = info.IncrId;
		this.FuncValue = info.FuncValue;
		this.RoleId = info.RoleId;
		this.SubEntryId = info.SubEntryId;
		PinballWeaponConfig? pinballWeaponConfigById = ConfigBase<PinballConfig>.Instance.GetPinballWeaponConfigById(this.Id);
		if (pinballWeaponConfigById == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PinballBattle;
			ELogAuthor author = ELogAuthor.CB;
			string message = "武器配置不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.MainEntryId = pinballWeaponConfigById.Value.MainEntry;
		this.Quality = pinballWeaponConfigById.Value.QualityId;
		this.Name = pinballWeaponConfigById.Value.Name;
		this.Type = pinballWeaponConfigById.Value.Type;
		this.Icon = pinballWeaponConfigById.Value.Icon;
		this.PersonType = pinballWeaponConfigById.Value.PersonType;
		int propListLength = pinballWeaponConfigById.Value.PropListLength;
		this.PropList = new int[propListLength];
		for (int i = 0; i < propListLength; i++)
		{
			int num = pinballWeaponConfigById.Value.PropList(i);
			this.PropList[i] = num;
		}
	}

	// Token: 0x060093B6 RID: 37814 RVA: 0x0026FF98 File Offset: 0x0026E198
	public bool GetCanDecompose()
	{
		return !this.GetIsLock() && this.RoleId == 0;
	}

	// Token: 0x060093B7 RID: 37815 RVA: 0x0026FFAD File Offset: 0x0026E1AD
	public void SetIsLock(bool lockVal)
	{
		if (lockVal)
		{
			this.FuncValue |= 1;
			return;
		}
		this.FuncValue &= -2;
	}

	// Token: 0x060093B8 RID: 37816 RVA: 0x0026FFD0 File Offset: 0x0026E1D0
	public bool GetIsLock()
	{
		return (this.FuncValue & 1) > 0;
	}

	// Token: 0x060093B9 RID: 37817 RVA: 0x0026FFDD File Offset: 0x0026E1DD
	public bool GetIsPersonWeapon()
	{
		return this.PersonType > 0;
	}

	// Token: 0x04004449 RID: 17481
	public int Id;

	// Token: 0x0400444A RID: 17482
	public int IncId;

	// Token: 0x0400444B RID: 17483
	public int FuncValue;

	// Token: 0x0400444C RID: 17484
	public int RoleId;

	// Token: 0x0400444D RID: 17485
	public int MainEntryId;

	// Token: 0x0400444E RID: 17486
	public int SubEntryId;

	// Token: 0x0400444F RID: 17487
	public int Quality;

	// Token: 0x04004450 RID: 17488
	public string Name = "";

	// Token: 0x04004451 RID: 17489
	public int Type;

	// Token: 0x04004452 RID: 17490
	public string Icon = "";

	// Token: 0x04004453 RID: 17491
	public int[] PropList = Array.Empty<int>();

	// Token: 0x04004454 RID: 17492
	public bool IsSelected;

	// Token: 0x04004455 RID: 17493
	public int PersonType;
}
