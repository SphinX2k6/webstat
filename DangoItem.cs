using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Dango;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B4F RID: 6991
[NullableContext(1)]
[Nullable(0)]
internal class DangoItem : UiPanelBase
{
	// Token: 0x0600CA1E RID: 51742 RVA: 0x0035B7F4 File Offset: 0x003599F4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnAddButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600CA1F RID: 51743 RVA: 0x0035B940 File Offset: 0x00359B40
	protected override UniTask OnBeforeStartAsync()
	{
		global::DangoItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<global::DangoItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600CA20 RID: 51744 RVA: 0x0035B984 File Offset: 0x00359B84
	private void OnAddButtonClick()
	{
		if (this.CurrentData == null || !this.CurrentData.IfSelf)
		{
			return;
		}
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		DangoSelectViewData dangoSelectViewData = new DangoSelectViewData();
		dangoSelectViewData.Index = this.CurrentData.Index;
		dangoSelectViewData.RoleConfigId = this.CurrentData.RoleConfigId;
		dangoSelectViewData.GroupIndex = ModelBase<EditFormationModel>.Instance.GetCurrentFormationId.GetValueOrDefault();
		AbyssDangoRoleData[] allDangoList = ModelBase<DangoAbyssModel>.Instance.GetAllDangoList();
		dangoSelectViewData.CurrentSelectDangoId = allDangoList[0].GetId();
		DangoItemData currentData = this.CurrentData;
		if (currentData == null || currentData.DangoId != 0)
		{
			dangoSelectViewData.CurrentSelectDangoId = this.CurrentData.DangoId;
		}
		else
		{
			EditBattleRoleSlotData[] getAllRoleSlotData = ModelBase<EditBattleTeamModel>.Instance.GetAllRoleSlotData;
			int num = allDangoList.Length;
			int num2 = getAllRoleSlotData.Length;
			for (int i = 0; i < num; i++)
			{
				bool flag = false;
				for (int j = 0; j < num2; j++)
				{
					if (getAllRoleSlotData[j].GetRoleConfigId != null)
					{
						AbyssDangoOwnerData roleOwnerData = ModelBase<DangoAbyssModel>.Instance.GetRoleOwnerData(id.Value, getAllRoleSlotData[j].GetRoleConfigId.Value);
						int? num3 = (roleOwnerData != null) ? new int?(roleOwnerData.DangoId) : null;
						int id2 = allDangoList[i].GetId();
						if (num3.GetValueOrDefault() == id2 & num3 != null)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					dangoSelectViewData.CurrentSelectDangoId = allDangoList[i].GetId();
					break;
				}
			}
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.DangoAbyssSelectDangoView, dangoSelectViewData, delegate(bool success, int viewId)
		{
			UiViewBase uiViewBase = Singleton<UiModel>.Instance.NormalStack.Peek();
			if (uiViewBase == null)
			{
				return;
			}
			uiViewBase.AddChildViewById(viewId);
		});
	}

	// Token: 0x0600CA21 RID: 51745 RVA: 0x0035BB38 File Offset: 0x00359D38
	protected override void OnStart()
	{
	}

	// Token: 0x0600CA22 RID: 51746 RVA: 0x0035BB3A File Offset: 0x00359D3A
	protected override void OnBeforeDestroy()
	{
		this.ClearRedDot();
	}

	// Token: 0x0600CA23 RID: 51747 RVA: 0x0035BB42 File Offset: 0x00359D42
	private void ClearRedDot()
	{
		if (this.RedDotBindState)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotDangoFormation, base.GetItem(6), 0);
			this.RedDotBindState = false;
		}
	}

	// Token: 0x0600CA24 RID: 51748 RVA: 0x0035BB6C File Offset: 0x00359D6C
	public void OnDangoInfoUpdate()
	{
		if (this.CurrentData == null)
		{
			return;
		}
		AbyssDangoRoleData dangoAbyssRoleData = ModelBase<DangoAbyssModel>.Instance.GetDangoAbyssRoleData(this.CurrentData.DangoId);
		if (dangoAbyssRoleData == null)
		{
			return;
		}
		int[] equipItemConfigIdList = dangoAbyssRoleData.GetEquipItemConfigIdList();
		this.CurrentData.DangoEquipIds = equipItemConfigIdList;
		this.RefreshQuality(this.CurrentData);
	}

	// Token: 0x0600CA25 RID: 51749 RVA: 0x0035BBBB File Offset: 0x00359DBB
	public void OnLevelUp(int dangoId, int level)
	{
		if (this.CurrentData == null)
		{
			return;
		}
		if (dangoId == this.CurrentData.DangoId)
		{
			this.CurrentData.Level = level;
			this.RefreshLevel(this.CurrentData);
		}
	}

	// Token: 0x0600CA26 RID: 51750 RVA: 0x0035BBEC File Offset: 0x00359DEC
	[NullableContext(2)]
	public void Refresh(DangoItemData data)
	{
		this.CurrentData = data;
		if (data == null)
		{
			return;
		}
		this.RefreshAddButtonState(data);
		this.RefreshAvatar(data);
		this.RefreshQuality(data);
		this.RefreshAvatarItem(data);
		this.RefreshLevel(data);
		this.ClearRedDot();
		if (data.IfSelf)
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotDangoFormation, base.GetItem(6), null, 0);
			this.RedDotBindState = true;
			return;
		}
		base.GetItem(6).SetUIActive(false);
	}

	// Token: 0x0600CA27 RID: 51751 RVA: 0x0035BC62 File Offset: 0x00359E62
	private void RefreshAvatarItem(DangoItemData data)
	{
		if (data.DangoId == 0)
		{
			base.GetItem(1).SetUIActive(false);
			return;
		}
		base.GetItem(1).SetUIActive(true);
	}

	// Token: 0x0600CA28 RID: 51752 RVA: 0x0035BC88 File Offset: 0x00359E88
	private void RefreshAvatar(DangoItemData data)
	{
		if (data.DangoId == 0)
		{
			base.GetTexture(3);
			return;
		}
		string formationIcon = ModelBase<DangoAbyssModel>.Instance.GetDangoAbyssRoleData(data.DangoId).GetFormationIcon();
		base.SetTextureByPath(formationIcon, base.GetTexture(3), null, null);
	}

	// Token: 0x0600CA29 RID: 51753 RVA: 0x0035BCD4 File Offset: 0x00359ED4
	private void RefreshQuality(DangoItemData data)
	{
		DangoCircleQualityData dangoCircleQualityData = new DangoCircleQualityData();
		int[] dangoEquipIds = data.DangoEquipIds;
		int num = dangoEquipIds.Length;
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		for (int i = 0; i < num; i++)
		{
			dictionary[i] = dangoEquipIds[i];
		}
		dangoCircleQualityData.PluginIdMap = dictionary;
		this.DangoCircleQualityItem.RefreshData(dangoCircleQualityData);
		this.DangoCircleQualityItem.SetActive(true);
	}

	// Token: 0x0600CA2A RID: 51754 RVA: 0x0035BD34 File Offset: 0x00359F34
	private void RefreshLevel(DangoItemData data)
	{
		if (data.DangoId == 0)
		{
			return;
		}
		int level = data.Level;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "AbyssDango_LV", new <>z__ReadOnlySingleElementList<object>(level.ToString()));
	}

	// Token: 0x0600CA2B RID: 51755 RVA: 0x0035BD74 File Offset: 0x00359F74
	private void RefreshAddButtonState(DangoItemData data)
	{
		bool uiactive = data.DangoId == 0;
		base.GetItem(5).SetUIActive(uiactive);
	}

	// Token: 0x040060BE RID: 24766
	[Nullable(2)]
	private DangoItemData CurrentData;

	// Token: 0x040060BF RID: 24767
	[Nullable(2)]
	private AbyssDangoCircleQualityItem DangoCircleQualityItem;

	// Token: 0x040060C0 RID: 24768
	private bool RedDotBindState;
}
