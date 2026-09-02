using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020021F7 RID: 8695
[NullableContext(1)]
[Nullable(0)]
public class LordGymRecordItem : UiPanelBase, IGridProxy<LordGym>
{
	// Token: 0x17001445 RID: 5189
	// (get) Token: 0x0601065F RID: 67167 RVA: 0x0047B0EA File Offset: 0x004792EA
	// (set) Token: 0x06010660 RID: 67168 RVA: 0x0047B0F2 File Offset: 0x004792F2
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public IScrollViewDelegate<IGridProxy<LordGym>, LordGym> ScrollViewDelegate { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x17001446 RID: 5190
	// (get) Token: 0x06010661 RID: 67169 RVA: 0x0047B0FB File Offset: 0x004792FB
	// (set) Token: 0x06010662 RID: 67170 RVA: 0x0047B103 File Offset: 0x00479303
	public int GridIndex { get; set; }

	// Token: 0x17001447 RID: 5191
	// (get) Token: 0x06010663 RID: 67171 RVA: 0x0047B10C File Offset: 0x0047930C
	// (set) Token: 0x06010664 RID: 67172 RVA: 0x0047B114 File Offset: 0x00479314
	public int DisplayIndex { get; set; }

	// Token: 0x06010665 RID: 67173 RVA: 0x0047B120 File Offset: 0x00479320
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUITexture))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
	}

	// Token: 0x06010666 RID: 67174 RVA: 0x0047B1F3 File Offset: 0x004793F3
	protected override void OnStart()
	{
		this.RoleLayout = new GenericLayout<RoleItem, RoleBrief>(base.GetHorizontalLayout(3), new Func<RoleItem>(this.CreateRoleItem), null, false, true);
	}

	// Token: 0x06010667 RID: 67175 RVA: 0x0047B216 File Offset: 0x00479416
	public void Clear()
	{
	}

	// Token: 0x06010668 RID: 67176 RVA: 0x0047B218 File Offset: 0x00479418
	public void OnSelected(bool fireEvent)
	{
	}

	// Token: 0x06010669 RID: 67177 RVA: 0x0047B21A File Offset: 0x0047941A
	public void OnDeselected(bool fireEvent)
	{
	}

	// Token: 0x0601066A RID: 67178 RVA: 0x0047B21C File Offset: 0x0047941C
	public void Refresh(LordGym data, bool isSelected, int gridIndex)
	{
		if (data.MonsterListLength == 0)
		{
			return;
		}
		int num = data.MonsterList(0);
		if (num == 0)
		{
			return;
		}
		string bossIconPath = this.GetBossIconPath(data.Id);
		base.SetTextureByPath(bossIconPath, base.GetTexture(7), null, null);
		string monsterName = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterName(num);
		base.GetText(0).SetText(monsterName, true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Text_InstanceDungeonRecommendLevel_Text", new <>z__ReadOnlySingleElementList<object>(data.MonsterLevel.ToString()));
		bool lordGymIsUnLock = ModelBase<LordGymModel>.Instance.GetLordGymIsUnLock(data.Id);
		bool lastGymFinish = ModelBase<LordGymModel>.Instance.GetLastGymFinish(data.Id);
		LordGymPassRecord lordGymPassRecord;
		ModelBase<LordGymModel>.Instance.LordGymRecord.TryGetValue(data.Id, out lordGymPassRecord);
		bool flag = lordGymPassRecord != null;
		bool uiactive = !lordGymIsUnLock || !lastGymFinish;
		bool uiactive2 = lordGymIsUnLock && lastGymFinish && !flag;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "PrefabTextItem_LordLocked_Text", Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "PrefabTextItem_LordNorecord_Text", Array.Empty<object>());
		base.GetItem(5).SetUIActive(uiactive);
		base.GetText(4).SetUIActive(uiactive2);
		base.GetText(2).SetUIActive(flag && lordGymIsUnLock);
		this.RoleLayout.SetActive(flag);
		if (lordGymIsUnLock && flag && lordGymPassRecord != null)
		{
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.SetText(Singleton<TimeUtil>.Instance.GetTimeString((double)lordGymPassRecord.PassTime), true);
			}
			this.RoleLayout.RefreshByData(this.GetRoleItemData(lordGymPassRecord), null, false);
		}
	}

	// Token: 0x0601066B RID: 67179 RVA: 0x0047B3C4 File Offset: 0x004795C4
	private List<RoleBrief> GetRoleItemData(LordGymPassRecord recordData)
	{
		List<RoleBrief> list = new List<RoleBrief>(3);
		for (int i = 0; i < 3; i++)
		{
			if (i < recordData.RoleIds.Count)
			{
				list.Add(recordData.RoleIds[i]);
			}
			else
			{
				RoleBrief roleBrief = RoleBrief.Create();
				roleBrief.RoleId = -1;
				roleBrief.Level = 1;
				list.Add(roleBrief);
			}
		}
		return list;
	}

	// Token: 0x0601066C RID: 67180 RVA: 0x0047B424 File Offset: 0x00479624
	private string GetBossIconPath(int gymId)
	{
		IReadOnlyList<LordGymEntrance> lordGymEntranceAllConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymEntranceAllConfig();
		int num = 0;
		if (lordGymEntranceAllConfig != null)
		{
			foreach (LordGymEntrance lordGymEntrance in lordGymEntranceAllConfig)
			{
				int[] array = lordGymEntrance.LordGymList();
				if (array != null)
				{
					bool flag = false;
					int[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						if (array2[i] == gymId)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						num = lordGymEntrance.Id;
						break;
					}
				}
			}
		}
		if (num == 0)
		{
			return "";
		}
		IReadOnlyList<SilentAreaDetection> allSilentAreaDetection = ConfigBase<AdventureGuideConfig>.Instance.GetAllSilentAreaDetection();
		if (allSilentAreaDetection != null)
		{
			foreach (SilentAreaDetection silentAreaDetection in allSilentAreaDetection)
			{
				if (silentAreaDetection.Secondary == 61 && silentAreaDetection.AdditionalId == num)
				{
					return silentAreaDetection.BigIcon;
				}
			}
		}
		return "";
	}

	// Token: 0x0601066D RID: 67181 RVA: 0x0047B530 File Offset: 0x00479730
	public object GetKey(LordGym data, int gridIndex)
	{
		return data.Id;
	}

	// Token: 0x0601066E RID: 67182 RVA: 0x0047B53E File Offset: 0x0047973E
	private RoleItem CreateRoleItem()
	{
		return new RoleItem();
	}

	// Token: 0x04008151 RID: 33105
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RoleItem, RoleBrief> RoleLayout;

	// Token: 0x020084BA RID: 33978
	[NullableContext(0)]
	private class ERecordComponents
	{
		// Token: 0x0402CF79 RID: 184185
		public const int TxtBoss = 0;

		// Token: 0x0402CF7A RID: 184186
		public const int TxtLevel = 1;

		// Token: 0x0402CF7B RID: 184187
		public const int TxtTime = 2;

		// Token: 0x0402CF7C RID: 184188
		public const int PnlHLayout = 3;

		// Token: 0x0402CF7D RID: 184189
		public const int TxtNoneRecord = 4;

		// Token: 0x0402CF7E RID: 184190
		public const int PnlLock = 5;

		// Token: 0x0402CF7F RID: 184191
		public const int TxtLock = 6;

		// Token: 0x0402CF80 RID: 184192
		public const int TexBossIcon = 7;
	}
}
