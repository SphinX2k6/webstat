using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002532 RID: 9522
[NullableContext(1)]
[Nullable(0)]
public class VisionNewRecommendPreviewView : UiViewBase
{
	// Token: 0x0601285C RID: 75868 RVA: 0x0051A360 File Offset: 0x00518560
	public VisionNewRecommendPreviewView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x17001772 RID: 6002
	// (get) Token: 0x0601285D RID: 75869 RVA: 0x0051A369 File Offset: 0x00518569
	public new IVisionNewRecommendPreviewViewOpenParam OpenParam
	{
		get
		{
			return (IVisionNewRecommendPreviewViewOpenParam)this.OpenParam;
		}
	}

	// Token: 0x0601285E RID: 75870 RVA: 0x0051A378 File Offset: 0x00518578
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(12, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(11, new Action(this.CloseCallBack))
		};
	}

	// Token: 0x0601285F RID: 75871 RVA: 0x0051A4D8 File Offset: 0x005186D8
	protected override UniTask OnBeforeStartAsync()
	{
		VisionNewRecommendPreviewView.<OnBeforeStartAsync>d__19 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionNewRecommendPreviewView.<OnBeforeStartAsync>d__19>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012860 RID: 75872 RVA: 0x0051A51C File Offset: 0x0051871C
	protected override void OnHandlePostLoadScene(bool isSceneLoad)
	{
		if (!this.SceneLoaded)
		{
			return;
		}
		if (Singleton<UiSceneManager>.Instance.HasRoleSystemRoleActor())
		{
			return;
		}
		int currentSelectRoleId = this.OpenParam.Proxy.CurrentSelectRoleId;
		this.ViewModel = new RoleViewViewModel(currentSelectRoleId, true, ERoleViewSource.Normal);
		this.ViewModel.HandleLoadScene(null);
	}

	// Token: 0x06012861 RID: 75873 RVA: 0x0051A56A File Offset: 0x0051876A
	protected override void OnHandleReleaseScene()
	{
		this.TryReleaseScene();
	}

	// Token: 0x06012862 RID: 75874 RVA: 0x0051A572 File Offset: 0x00518772
	private void TryReleaseScene()
	{
		if (this.ViewModel != null)
		{
			this.ViewModel.HandleReleaseScene();
		}
		this.ViewModel = null;
	}

	// Token: 0x06012863 RID: 75875 RVA: 0x0051A58E File Offset: 0x0051878E
	protected override void OnBeforeDestroy()
	{
		this.TryReleaseScene();
	}

	// Token: 0x06012864 RID: 75876 RVA: 0x0051A596 File Offset: 0x00518796
	protected override void OnStart()
	{
		this.InitData();
		this.InitCaptionItem();
		this.InitAttributeLayout();
		this.RefreshRoleInfo();
		this.RefreshCurEquip();
		this.RefreshRecommendEquip();
		this.RefreshCurEquipDetail();
		this.RefreshRecommendEquipDetail();
		this.RefreshAttributeScroller();
		this.RefreshApplyBtn();
	}

	// Token: 0x06012865 RID: 75877 RVA: 0x0051A5D4 File Offset: 0x005187D4
	private void InitData()
	{
		this.CurUniqueIdList = ModelBase<PhantomBattleModel>.Instance.GetBattleDataById(this.OpenParam.Proxy.CurrentSelectRoleId).GetIncrIdList().ToList<int>();
		this.RecommendUniqueIdList = ModelBase<VisionRecommendModel>.Instance.GetRecommendEquipUniqueIdListNew(this.OpenParam.Proxy.CurrentSelectRoleId, this.OpenParam.Proxy.CurrentSelectFirstVisionMonsterId, this.OpenParam.Proxy.GetCurrentSelectRecommendInfo());
		bool isBothEmpty;
		if (this.CurUniqueIdList.All((int id) => id == 0))
		{
			isBothEmpty = this.RecommendUniqueIdList.All((int id) => id == 0);
		}
		else
		{
			isBothEmpty = false;
		}
		this.IsBothEmpty = isBothEmpty;
		this.IsSameEquip = this.CheckUniqueIdListEqual(this.CurUniqueIdList, this.RecommendUniqueIdList);
		this.RecommendAttrIdSet = this.GetRecommendAttrIds(this.OpenParam.Proxy.CurrentSelectRoleId);
	}

	// Token: 0x06012866 RID: 75878 RVA: 0x0051A6E0 File Offset: 0x005188E0
	private bool CheckUniqueIdListEqual(IReadOnlyList<int> listA, IReadOnlyList<int> listB)
	{
		if (listA[0] != listB[0])
		{
			return false;
		}
		List<int> list = (from x in listA.Skip(1)
		orderby x
		select x).ToList<int>();
		List<int> list2 = (from x in listB.Skip(1)
		orderby x
		select x).ToList<int>();
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] != list2[i])
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06012867 RID: 75879 RVA: 0x0051A788 File Offset: 0x00518988
	private void RefreshApplyBtn()
	{
		this.ApplyBtn = new ButtonItem(base.GetItem(10));
		if (this.IsBothEmpty)
		{
			ButtonItem applyBtn = this.ApplyBtn;
			if (applyBtn != null)
			{
				applyBtn.SetActive(false);
			}
			base.GetButton(11).RootUIComp.Get().SetUIActive(true);
			return;
		}
		if (this.IsSameEquip)
		{
			this.ApplyBtn.SetEnableClick(false);
			this.ApplyBtn.TrySetLocalTextNew("PhantomRecommend_Tips05", Array.Empty<object>());
			return;
		}
		this.ApplyBtn.SetEnableClick(true);
		this.ApplyBtn.TrySetLocalTextNew("PhantomRecommend_Button05", Array.Empty<object>());
		this.ApplyBtn.SetFunction(new Action<int>(this.OnClickApplyBtn));
	}

	// Token: 0x06012868 RID: 75880 RVA: 0x0051A840 File Offset: 0x00518A40
	private void InitCaptionItem()
	{
		this.Caption = new PopupCaptionItem(base.GetItem(0));
		this.Caption.SetCloseCallBack(new Action(this.CloseCallBack));
		this.Caption.SetHelpBtnActive(false);
	}

	// Token: 0x06012869 RID: 75881 RVA: 0x0051A877 File Offset: 0x00518A77
	private void CloseCallBack()
	{
		base.CloseMe(null);
	}

	// Token: 0x0601286A RID: 75882 RVA: 0x0051A880 File Offset: 0x00518A80
	private void InitAttributeLayout()
	{
		this.AttributeLayout = new GenericScrollViewNew<VisionNewRecommendPreviewAttrItem, VisionAssembleAttrData>(base.GetScrollViewWithScrollbar(7), new Func<VisionNewRecommendPreviewAttrItem>(this.InitAttributeItem), null, false, null);
	}

	// Token: 0x0601286B RID: 75883 RVA: 0x0051A8A3 File Offset: 0x00518AA3
	private VisionNewRecommendPreviewAttrItem InitAttributeItem()
	{
		return new VisionNewRecommendPreviewAttrItem();
	}

	// Token: 0x0601286C RID: 75884 RVA: 0x0051A8AC File Offset: 0x00518AAC
	private void RefreshRoleInfo()
	{
		RoleSkin? roleSkinConfig = this.GetRoleSkinConfig();
		if (roleSkinConfig == null)
		{
			return;
		}
		this.RefreshRoleIcon(roleSkinConfig.Value);
		this.RefreshRoleName(roleSkinConfig.Value);
	}

	// Token: 0x0601286D RID: 75885 RVA: 0x0051A8E4 File Offset: 0x00518AE4
	private RoleSkin? GetRoleSkinConfig()
	{
		int currentSelectRoleId = this.OpenParam.Proxy.CurrentSelectRoleId;
		RoleSkinModel instance = ModelBase<RoleSkinModel>.Instance;
		RoleSkinData roleSkinData = (instance != null) ? instance.GetRoleSkinDataByRoleId(currentSelectRoleId) : null;
		if (roleSkinData != null)
		{
			return new RoleSkin?(roleSkinData.GetRoleSkinConfig());
		}
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(currentSelectRoleId);
		if (roleConfig == null)
		{
			return null;
		}
		return ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(roleConfig.Value.SkinId);
	}

	// Token: 0x0601286E RID: 75886 RVA: 0x0051A960 File Offset: 0x00518B60
	private void RefreshRoleIcon(RoleSkin roleSkinConfig)
	{
		string tag = "RoleIcon1";
		string roleSkinConfigParam = ConfigBase<ComponentConfig>.Instance.GetRoleSkinConfigParam(tag);
		if (roleSkinConfigParam != null && roleSkinConfigParam != "")
		{
			PropertyInfo property = roleSkinConfig.GetType().GetProperty(roleSkinConfigParam);
			if (property != null)
			{
				string text = property.GetValue(roleSkinConfig) as string;
				if (text != null)
				{
					base.SetTextureByPath(text, base.GetTexture(1), null, null);
				}
			}
		}
	}

	// Token: 0x0601286F RID: 75887 RVA: 0x0051A9D8 File Offset: 0x00518BD8
	private void RefreshRoleName(RoleSkin roleSkinConfig)
	{
		UUIText text = base.GetText(2);
		if (text == null)
		{
			return;
		}
		text.SetText(ConfigBase<RoleConfig>.Instance.GetRoleName(roleSkinConfig.Name), true);
	}

	// Token: 0x06012870 RID: 75888 RVA: 0x0051AA00 File Offset: 0x00518C00
	private void RefreshCurEquip()
	{
		List<VisionNewRecommendPhantomItemData> data = this.BuildCurEquipData();
		VisionNewRecommendPreviewEquipItem curEquipPanel = this.CurEquipPanel;
		if (curEquipPanel == null)
		{
			return;
		}
		curEquipPanel.Update(data);
	}

	// Token: 0x06012871 RID: 75889 RVA: 0x0051AA28 File Offset: 0x00518C28
	[return: Nullable(new byte[]
	{
		1,
		2
	})]
	private List<VisionNewRecommendPhantomItemData> BuildCurEquipData()
	{
		int num = 5;
		List<VisionNewRecommendPhantomItemData> list = new List<VisionNewRecommendPhantomItemData>
		{
			null,
			null,
			null,
			null,
			null
		};
		for (int i = 0; i < num; i++)
		{
			int roleIndexPhantomId = ModelBase<PhantomBattleModel>.Instance.GetRoleIndexPhantomId(this.OpenParam.Proxy.CurrentSelectRoleId, i);
			if (roleIndexPhantomId != 0)
			{
				PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(roleIndexPhantomId);
				if (phantomBattleData != null)
				{
					list[i] = new VisionNewRecommendPhantomItemData
					{
						PhantomId = phantomBattleData.GetConfigId(true),
						FetterGroupId = phantomBattleData.GetFetterGroupId(),
						Cost = phantomBattleData.GetCost(),
						UniqueId = roleIndexPhantomId,
						Level = phantomBattleData.GetPhantomLevel()
					};
				}
			}
		}
		return list;
	}

	// Token: 0x06012872 RID: 75890 RVA: 0x0051AAE8 File Offset: 0x00518CE8
	private void RefreshRecommendEquip()
	{
		List<VisionNewRecommendPhantomItemData> data = this.BuildRecommendEquipData();
		VisionNewRecommendPreviewEquipItem recommendEquipPanel = this.RecommendEquipPanel;
		if (recommendEquipPanel == null)
		{
			return;
		}
		recommendEquipPanel.Update(data);
	}

	// Token: 0x06012873 RID: 75891 RVA: 0x0051AB10 File Offset: 0x00518D10
	[return: Nullable(new byte[]
	{
		1,
		2
	})]
	private List<VisionNewRecommendPhantomItemData> BuildRecommendEquipData()
	{
		if (this.OpenParam.Proxy.GetCurrentSelectRecommendInfo() == null)
		{
			return new List<VisionNewRecommendPhantomItemData>();
		}
		List<VisionNewRecommendPhantomItemData> list = new List<VisionNewRecommendPhantomItemData>();
		foreach (int uniqueId in this.RecommendUniqueIdList)
		{
			PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId);
			if (phantomBattleData != null)
			{
				list.Add(new VisionNewRecommendPhantomItemData
				{
					PhantomId = phantomBattleData.GetConfigId(true),
					FetterGroupId = phantomBattleData.GetFetterGroupId(),
					Cost = phantomBattleData.GetCost(),
					UniqueId = uniqueId,
					Level = phantomBattleData.GetPhantomLevel()
				});
			}
		}
		return list;
	}

	// Token: 0x06012874 RID: 75892 RVA: 0x0051ABAD File Offset: 0x00518DAD
	private void RefreshCurEquipDetail()
	{
		VisionNewRecommendPreviewTopItem curEquipTopItem = this.CurEquipTopItem;
		if (curEquipTopItem == null)
		{
			return;
		}
		curEquipTopItem.Refresh(this.BuildTopData(false));
	}

	// Token: 0x06012875 RID: 75893 RVA: 0x0051ABC6 File Offset: 0x00518DC6
	private void RefreshRecommendEquipDetail()
	{
		VisionNewRecommendPreviewTopItem recommendEquipTopItem = this.RecommendEquipTopItem;
		if (recommendEquipTopItem == null)
		{
			return;
		}
		recommendEquipTopItem.Refresh(this.BuildTopData(true));
	}

	// Token: 0x06012876 RID: 75894 RVA: 0x0051ABE0 File Offset: 0x00518DE0
	private HashSet<int> GetRecommendAttrIds(int roleId)
	{
		HashSet<int> hashSet = new HashSet<int>();
		Dictionary<int, VisionAttrRecommendInfo> roleAllAttrRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetRoleAllAttrRecommendInfo(roleId);
		if (roleAllAttrRecommendInfo == null)
		{
			return hashSet;
		}
		foreach (VisionAttrRecommendInfo visionAttrRecommendInfo in roleAllAttrRecommendInfo.Values)
		{
			foreach (AttrRecommendInfo attrRecommendInfo in visionAttrRecommendInfo.GetMainAttrRecommendInfo())
			{
				hashSet.Add(attrRecommendInfo.GetAttrId());
			}
			foreach (AttrRecommendInfo attrRecommendInfo2 in visionAttrRecommendInfo.GetSubAttrRecommendInfo())
			{
				hashSet.Add(attrRecommendInfo2.GetAttrId());
			}
		}
		return hashSet;
	}

	// Token: 0x06012877 RID: 75895 RVA: 0x0051ACE0 File Offset: 0x00518EE0
	private VisionNewRecommendPreviewTopData BuildTopData(bool isRecommend)
	{
		List<int> list = isRecommend ? this.RecommendUniqueIdList.ToList<int>() : this.CurUniqueIdList;
		List<VisionFetterData> list2 = this.FilterSameFetterData(ModelBase<VisionEquipGroupModel>.Instance.GetVisionFetterDataByIncIdList(list));
		List<VisionAssembleSuitItemData> list3 = new List<VisionAssembleSuitItemData>();
		foreach (VisionFetterData data in list2)
		{
			VisionAssembleSuitItemData visionAssembleSuitItemData = new VisionAssembleSuitItemData();
			visionAssembleSuitItemData.Phrase(data);
			list3.Add(visionAssembleSuitItemData);
		}
		int num = 0;
		foreach (int uniqueId in list)
		{
			int num2 = num;
			PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId);
			num = num2 + ((phantomBattleData != null) ? phantomBattleData.GetCost() : 0);
		}
		return new VisionNewRecommendPreviewTopData
		{
			Cost = num,
			SuitList = list3
		};
	}

	// Token: 0x06012878 RID: 75896 RVA: 0x0051ADD8 File Offset: 0x00518FD8
	private List<VisionFetterData> FilterSameFetterData(List<VisionFetterData> dataList)
	{
		List<VisionFetterData> list = new List<VisionFetterData>();
		Dictionary<int, VisionFetterData> dictionary = new Dictionary<int, VisionFetterData>();
		foreach (VisionFetterData visionFetterData in dataList)
		{
			dictionary[visionFetterData.FetterGroupId] = visionFetterData;
		}
		foreach (VisionFetterData item in dictionary.Values)
		{
			list.Add(item);
		}
		return list;
	}

	// Token: 0x06012879 RID: 75897 RVA: 0x0051AE80 File Offset: 0x00519080
	private void RefreshAttributeScroller()
	{
		List<VisionAssembleAttrData> list = this.BuildAttrDetailData();
		bool flag = list.Count > 0;
		base.GetScrollViewWithScrollbar(7).RootUIComp.Get().SetUIActive(flag);
		base.GetItem(12).SetUIActive(!flag);
		GenericScrollViewNew<VisionNewRecommendPreviewAttrItem, VisionAssembleAttrData> attributeLayout = this.AttributeLayout;
		if (attributeLayout == null)
		{
			return;
		}
		attributeLayout.RefreshByData(list, null, false);
	}

	// Token: 0x0601287A RID: 75898 RVA: 0x0051AEDC File Offset: 0x005190DC
	private List<VisionAssembleAttrData> BuildAttrDetailData()
	{
		List<VisionAssembleAttrData> visionAttrDataListByIncIdList = this.GetVisionAttrDataListByIncIdList(this.CurUniqueIdList);
		List<VisionAssembleAttrData> visionAttrDataListByIncIdList2 = this.GetVisionAttrDataListByIncIdList(this.RecommendUniqueIdList.ToList<int>());
		this.CombineAttrList(visionAttrDataListByIncIdList2, visionAttrDataListByIncIdList);
		visionAttrDataListByIncIdList2.Sort(new Comparison<VisionAssembleAttrData>(this.SortAttrList));
		return visionAttrDataListByIncIdList2;
	}

	// Token: 0x0601287B RID: 75899 RVA: 0x0051AF24 File Offset: 0x00519124
	private List<VisionAssembleAttrData> GetVisionAttrDataListByIncIdList(IReadOnlyList<int> incIdList)
	{
		HashSet<int> recommendAttrIdSet = this.RecommendAttrIdSet;
		List<VisionAssembleAttrData> list = new List<VisionAssembleAttrData>();
		int count = incIdList.Count;
		for (int i = 0; i < count; i++)
		{
			PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(incIdList[i]);
			if (phantomBattleData != null)
			{
				foreach (Aki.Protocol.PhantomPropInfo phantomPropInfo in phantomBattleData.GetPhantomMainProp())
				{
					PhantomMainPropItem phantomMainPropertyItemId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomMainPropertyItemId(phantomPropInfo.PhantomPropId);
					bool flag = phantomMainPropertyItemId.AddType == 2;
					bool flag2 = false;
					foreach (VisionAssembleAttrData visionAssembleAttrData in list)
					{
						if (visionAssembleAttrData.AttrId == phantomMainPropertyItemId.PropId && visionAssembleAttrData.IfPercentage == flag)
						{
							visionAssembleAttrData.CurrentValue += phantomPropInfo.Value;
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						VisionAssembleAttrData visionAssembleAttrData2 = new VisionAssembleAttrData();
						visionAssembleAttrData2.AttrId = phantomMainPropertyItemId.PropId;
						visionAssembleAttrData2.IfPercentage = flag;
						visionAssembleAttrData2.CurrentValue += phantomPropInfo.Value;
						visionAssembleAttrData2.IsHighLight = recommendAttrIdSet.Contains(phantomMainPropertyItemId.PropId);
						list.Add(visionAssembleAttrData2);
					}
				}
				foreach (Aki.Protocol.PhantomPropInfo phantomPropInfo2 in phantomBattleData.GetPhantomSubProp())
				{
					PhantomSubProperty phantomSubPropertyById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSubPropertyById(phantomPropInfo2.PhantomPropId);
					bool flag3 = phantomSubPropertyById.AddType == 2;
					bool flag4 = false;
					foreach (VisionAssembleAttrData visionAssembleAttrData3 in list)
					{
						if (visionAssembleAttrData3.AttrId == phantomSubPropertyById.PropId && visionAssembleAttrData3.IfPercentage == flag3)
						{
							visionAssembleAttrData3.CurrentValue += phantomPropInfo2.Value;
							flag4 = true;
							break;
						}
					}
					if (!flag4)
					{
						VisionAssembleAttrData visionAssembleAttrData4 = new VisionAssembleAttrData();
						visionAssembleAttrData4.AttrId = phantomSubPropertyById.PropId;
						visionAssembleAttrData4.IfPercentage = flag3;
						visionAssembleAttrData4.CurrentValue += phantomPropInfo2.Value;
						visionAssembleAttrData4.IsHighLight = recommendAttrIdSet.Contains(phantomSubPropertyById.PropId);
						list.Add(visionAssembleAttrData4);
					}
				}
			}
		}
		return list;
	}

	// Token: 0x0601287C RID: 75900 RVA: 0x0051B1C4 File Offset: 0x005193C4
	private int SortAttrList(VisionAssembleAttrData dataB, VisionAssembleAttrData dataA)
	{
		int priority = dataA.GetPriority();
		int priority2 = dataB.GetPriority();
		bool flag = priority != 0;
		bool flag2 = priority2 != 0;
		if (flag && flag2)
		{
			if (priority == priority2)
			{
				int num = (!dataA.IfPercentage) ? 1 : 0;
				int num2 = (!dataB.IfPercentage) ? 1 : 0;
				return num - num2;
			}
			return priority - priority2;
		}
		else
		{
			if (flag)
			{
				return -1;
			}
			if (flag2)
			{
				return 1;
			}
			return dataA.GetId() - dataB.GetId();
		}
	}

	// Token: 0x0601287D RID: 75901 RVA: 0x0051B228 File Offset: 0x00519428
	private void CombineAttrList(List<VisionAssembleAttrData> compareAttrDataList, List<VisionAssembleAttrData> currentAttrDataList)
	{
		int count = currentAttrDataList.Count;
		for (int i = 0; i < count; i++)
		{
			VisionAssembleAttrData visionAssembleAttrData = currentAttrDataList[i];
			bool flag = false;
			foreach (VisionAssembleAttrData visionAssembleAttrData2 in compareAttrDataList)
			{
				if (visionAssembleAttrData2.AttrId == visionAssembleAttrData.AttrId && visionAssembleAttrData2.IfPercentage == visionAssembleAttrData.IfPercentage)
				{
					visionAssembleAttrData2.CompareValue = visionAssembleAttrData.CurrentValue;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				compareAttrDataList.Add(new VisionAssembleAttrData
				{
					AttrId = visionAssembleAttrData.AttrId,
					IfPercentage = visionAssembleAttrData.IfPercentage,
					CompareValue = visionAssembleAttrData.CurrentValue,
					CompareMode = true
				});
			}
		}
	}

	// Token: 0x0601287E RID: 75902 RVA: 0x0051B304 File Offset: 0x00519504
	private void OnClickApplyBtn(int _)
	{
		if (this.OpenParam.Proxy.GetCurrentSelectRecommendInfo() == null)
		{
			return;
		}
		ControllerBase<PhantomBattleController>.Instance.ApplyRecommendEquip(this.OpenParam.Proxy.CurrentSelectRoleId, this.RecommendUniqueIdList.ToList<int>(), delegate
		{
			base.CloseMe(null);
			Action onApplySuccess = this.OpenParam.OnApplySuccess;
			if (onApplySuccess == null)
			{
				return;
			}
			onApplySuccess();
		});
	}

	// Token: 0x04009061 RID: 36961
	[Nullable(2)]
	private PopupCaptionItem Caption;

	// Token: 0x04009062 RID: 36962
	[Nullable(2)]
	private VisionNewRecommendPreviewEquipItem CurEquipPanel;

	// Token: 0x04009063 RID: 36963
	[Nullable(2)]
	private VisionNewRecommendPreviewEquipItem RecommendEquipPanel;

	// Token: 0x04009064 RID: 36964
	[Nullable(2)]
	private VisionNewRecommendPreviewTopItem CurEquipTopItem;

	// Token: 0x04009065 RID: 36965
	[Nullable(2)]
	private VisionNewRecommendPreviewTopItem RecommendEquipTopItem;

	// Token: 0x04009066 RID: 36966
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<VisionNewRecommendPreviewAttrItem, VisionAssembleAttrData> AttributeLayout;

	// Token: 0x04009067 RID: 36967
	[Nullable(2)]
	private ButtonItem ApplyBtn;

	// Token: 0x04009068 RID: 36968
	[Nullable(2)]
	private RoleViewViewModel ViewModel;

	// Token: 0x04009069 RID: 36969
	[Nullable(2)]
	private List<int> CurUniqueIdList;

	// Token: 0x0400906A RID: 36970
	[Nullable(2)]
	private int[] RecommendUniqueIdList;

	// Token: 0x0400906B RID: 36971
	private bool IsSameEquip;

	// Token: 0x0400906C RID: 36972
	private bool IsBothEmpty;

	// Token: 0x0400906D RID: 36973
	[Nullable(2)]
	private HashSet<int> RecommendAttrIdSet;

	// Token: 0x02008857 RID: 34903
	[Nullable(0)]
	private static class ETextId
	{
		// Token: 0x0402E0D3 RID: 188627
		public const string Apply = "PhantomRecommend_Button05";

		// Token: 0x0402E0D4 RID: 188628
		public const string ApplySameEquip = "PhantomRecommend_Tips05";
	}

	// Token: 0x02008858 RID: 34904
	[NullableContext(0)]
	private enum EComp
	{
		// Token: 0x0402E0D6 RID: 188630
		Caption,
		// Token: 0x0402E0D7 RID: 188631
		RoleIcon,
		// Token: 0x0402E0D8 RID: 188632
		RoleName,
		// Token: 0x0402E0D9 RID: 188633
		CurEquipItem,
		// Token: 0x0402E0DA RID: 188634
		RecommendEquipItem,
		// Token: 0x0402E0DB RID: 188635
		LeftTop,
		// Token: 0x0402E0DC RID: 188636
		RightTop,
		// Token: 0x0402E0DD RID: 188637
		Scroll,
		// Token: 0x0402E0DE RID: 188638
		ScrollContent,
		// Token: 0x0402E0DF RID: 188639
		ScrollItem,
		// Token: 0x0402E0E0 RID: 188640
		ApplyBtn,
		// Token: 0x0402E0E1 RID: 188641
		BackBtn,
		// Token: 0x0402E0E2 RID: 188642
		EmptyItem
	}
}
