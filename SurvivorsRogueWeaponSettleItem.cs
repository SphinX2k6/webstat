using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B77 RID: 11127
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SurvivorsRogueWeaponSettleItem : GridProxyAbstract<ISurvivorsWeaponGridData>
{
	// Token: 0x0601627C RID: 90748 RVA: 0x00625AE8 File Offset: 0x00623CE8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(11, typeof(UUIItem))
		};
	}

	// Token: 0x0601627D RID: 90749 RVA: 0x00625BC8 File Offset: 0x00623DC8
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsRogueWeaponSettleItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsRogueWeaponSettleItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601627E RID: 90750 RVA: 0x00625C0B File Offset: 0x00623E0B
	protected override void OnStart()
	{
		this.EvolveItemList = new GenericLayout<SurvivorsRogueWeaponEvolveItem, IWeaponEvolveData>(base.GetHorizontalLayout(10), new Func<SurvivorsRogueWeaponEvolveItem>(this.CreateEvolveItem), null, false, true);
		this.RootActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.OnEventSequence));
	}

	// Token: 0x0601627F RID: 90751 RVA: 0x00625C4B File Offset: 0x00623E4B
	protected override void OnBeforeDestroy()
	{
		this.ScrollingNumberTool.Clear();
		this.RootActor.OnSequencePlayEvent.Unbind();
	}

	// Token: 0x06016280 RID: 90752 RVA: 0x00625C68 File Offset: 0x00623E68
	private SurvivorsRogueWeaponEvolveItem CreateEvolveItem()
	{
		return new SurvivorsRogueWeaponEvolveItem();
	}

	// Token: 0x06016281 RID: 90753 RVA: 0x00625C6F File Offset: 0x00623E6F
	public override void Refresh(ISurvivorsWeaponGridData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		if (data.IsDisable)
		{
			this.SetStateDisable();
			return;
		}
		if (data.IsLock)
		{
			this.SetStateLock();
			return;
		}
		this.SetStateNormal();
	}

	// Token: 0x06016282 RID: 90754 RVA: 0x00625C9C File Offset: 0x00623E9C
	private void OnEventSequence(string sequenceName, string eventName)
	{
		if (sequenceName == "Start" && eventName == "Got")
		{
			this.PlayAnim();
		}
	}

	// Token: 0x06016283 RID: 90755 RVA: 0x00625CC0 File Offset: 0x00623EC0
	public void PlayAnim()
	{
		if (this.AnimPlayState)
		{
			return;
		}
		this.AnimPlayState = true;
		if (this.Data == null)
		{
			return;
		}
		if (this.Data.IsLock || this.Data.IsDisable)
		{
			return;
		}
		this.RefreshEvolveItemList();
		this.ScrollingNumberTool.StartScrolling();
	}

	// Token: 0x06016284 RID: 90756 RVA: 0x00625D12 File Offset: 0x00623F12
	private void SetStateDisable()
	{
		base.GetItem(0).SetUIActive(true);
		base.GetItem(1).SetUIActive(false);
		base.GetItem(3).SetUIActive(false);
	}

	// Token: 0x06016285 RID: 90757 RVA: 0x00625D3B File Offset: 0x00623F3B
	private void SetStateLock()
	{
		base.GetItem(0).SetUIActive(false);
		base.GetItem(1).SetUIActive(true);
		base.GetItem(3).SetUIActive(false);
	}

	// Token: 0x06016286 RID: 90758 RVA: 0x00625D64 File Offset: 0x00623F64
	private void SetStateNormal()
	{
		base.GetItem(0).SetUIActive(false);
		base.GetItem(1).SetUIActive(false);
		base.GetItem(3).SetUIActive(true);
		SurvivorsWeaponGainData weaponData = this.Data.WeaponData;
		if (weaponData == null)
		{
			return;
		}
		SurvivorsWeapon? survivorsWeapon = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsWeapon(weaponData.ConfigId);
		if (survivorsWeapon == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "SurvivorsCombat_Lv", new <>z__ReadOnlySingleElementList<object>(weaponData.Data.Level));
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), survivorsWeapon.Value.Name, Array.Empty<object>());
		this.ScrollingNumberTool.Init(0, weaponData.Data.KillMonsterCount, delegate(float value)
		{
			base.GetText(8).SetText(MathF.Round(value).ToString(), true);
		}, 1000);
		base.SetTextureShowUntilLoaded(survivorsWeapon.Value.Icon, base.GetTexture(4), null);
	}

	// Token: 0x06016287 RID: 90759 RVA: 0x00625E58 File Offset: 0x00624058
	private void RefreshEvolveItemList()
	{
		SurvivorsWeaponGainData weaponData = this.Data.WeaponData;
		if (weaponData == null)
		{
			return;
		}
		SurvivorsWeapon? survivorsWeapon = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsWeapon(weaponData.ConfigId);
		if (survivorsWeapon == null)
		{
			return;
		}
		List<IWeaponEvolveData> list = new List<IWeaponEvolveData>();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		for (int i = 0; i < survivorsWeapon.Value.EvolveIdsLength; i++)
		{
			DicIntInt value = survivorsWeapon.Value.EvolveIds(i).Value;
			dictionary[value.Value] = value.Key;
		}
		List<int> list2 = new List<int>();
		foreach (int item in dictionary.Values)
		{
			list2.Add(item);
		}
		for (int j = 0; j < weaponData.Data.Evolves.Count; j++)
		{
			WeaponEvolveData item2 = new WeaponEvolveData
			{
				EvolveId = weaponData.Data.Evolves[j],
				IsUnlock = true,
				ShowLine = (j > 0)
			};
			list.Add(item2);
		}
		foreach (int num in list2)
		{
			if (!weaponData.Data.Evolves.Contains(num))
			{
				WeaponEvolveData item3 = new WeaponEvolveData
				{
					EvolveId = num,
					IsUnlock = false,
					ShowLine = (list.Count != 0)
				};
				list.Add(item3);
			}
		}
		this.EvolveItemList.RefreshByData(list, null, true);
	}

	// Token: 0x0400AB5A RID: 43866
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<SurvivorsRogueWeaponEvolveItem, IWeaponEvolveData> EvolveItemList;

	// Token: 0x0400AB5B RID: 43867
	protected ISurvivorsWeaponGridData Data;

	// Token: 0x0400AB5C RID: 43868
	private readonly ScrollingNumberTool ScrollingNumberTool = new ScrollingNumberTool();

	// Token: 0x0400AB5D RID: 43869
	private bool AnimPlayState;
}
