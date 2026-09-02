using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020028AB RID: 10411
[NullableContext(1)]
[Nullable(0)]
public class RoleSkillBranchPopView : UiViewBase
{
	// Token: 0x06014AB5 RID: 84661 RVA: 0x005B976E File Offset: 0x005B796E
	public RoleSkillBranchPopView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06014AB6 RID: 84662 RVA: 0x005B9790 File Offset: 0x005B7990
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06014AB7 RID: 84663 RVA: 0x005B98A0 File Offset: 0x005B7AA0
	protected override void OnStart()
	{
		this.RoleLayout = new GenericLayout<RoleSkillBranchPopView.RoleSkillBranchPopViewRoleItem, RoleSkillBranchPopView.RoleData>(base.GetHorizontalLayout(1), new Func<RoleSkillBranchPopView.RoleSkillBranchPopViewRoleItem>(this.CreateRoleItem), base.GetItem(2).GetOwner() as AUIBaseActor, false, true);
		this.TabLayout = new GenericLayout<RoleSkillBranchPopView.TeamTabItem, int>(base.GetHorizontalLayout(4), new Func<RoleSkillBranchPopView.TeamTabItem>(this.CreateTeamTabItem), base.GetItem(5).GetOwner() as AUIBaseActor, false, true);
		RoleSkillBranchPopViewParams roleSkillBranchPopViewParams = this.OpenParam as RoleSkillBranchPopViewParams;
		if (roleSkillBranchPopViewParams == null)
		{
			return;
		}
		this.TabData.Clear();
		this.TabIndex.Clear();
		for (int i = 0; i < roleSkillBranchPopViewParams.RoleSkillBranchTeamTabDataList.Count; i++)
		{
			RoleSkillBranchTeamTabData roleSkillBranchTeamTabData = roleSkillBranchPopViewParams.RoleSkillBranchTeamTabDataList[i];
			if (roleSkillBranchTeamTabData.RoleSkillBranchTeamDataList.Count > 0)
			{
				this.TabIndex.Add(roleSkillBranchTeamTabData.TeamIndex);
				List<RoleSkillBranchPopView.RoleData> list = new List<RoleSkillBranchPopView.RoleData>(roleSkillBranchTeamTabData.RoleSkillBranchTeamDataList.Count);
				for (int j = 0; j < roleSkillBranchTeamTabData.RoleSkillBranchTeamDataList.Count; j++)
				{
					ValueTuple<int, int> valueTuple = roleSkillBranchTeamTabData.RoleSkillBranchTeamDataList[j];
					list.Add(new RoleSkillBranchPopView.RoleData
					{
						RoleId = valueTuple.Item1,
						SkillBranchIndex = valueTuple.Item2
					});
				}
				this.TabData.Add(list);
			}
		}
		int selectTabPos = 0;
		if (this.TabIndex.Count > 1)
		{
			selectTabPos = roleSkillBranchPopViewParams.PreferredTabIndex.GetValueOrDefault();
		}
		List<int> data = new List<int>(this.TabIndex);
		GenericLayout<RoleSkillBranchPopView.TeamTabItem, int> tabLayout = this.TabLayout;
		if (tabLayout != null)
		{
			tabLayout.RefreshByData(data, delegate
			{
				this.SelectTab(selectTabPos, true);
			}, false);
		}
		base.GetItem(3).SetUIActive(this.TabIndex.Count == 1);
		base.GetItem(6).SetUIActive(this.TabIndex.Count > 1);
		base.GetHorizontalLayout(4).RootUIComp.Get().SetUIActive(this.TabIndex.Count > 1);
	}

	// Token: 0x06014AB8 RID: 84664 RVA: 0x005B9AB2 File Offset: 0x005B7CB2
	private RoleSkillBranchPopView.RoleSkillBranchPopViewRoleItem CreateRoleItem()
	{
		return new RoleSkillBranchPopView.RoleSkillBranchPopViewRoleItem();
	}

	// Token: 0x06014AB9 RID: 84665 RVA: 0x005B9AB9 File Offset: 0x005B7CB9
	private RoleSkillBranchPopView.TeamTabItem CreateTeamTabItem()
	{
		return new RoleSkillBranchPopView.TeamTabItem
		{
			SelectHandler = new Action<int>(this.ClickTabHandler)
		};
	}

	// Token: 0x06014ABA RID: 84666 RVA: 0x005B9AD2 File Offset: 0x005B7CD2
	private void ClickTabHandler(int index)
	{
		this.SelectTab(index, true);
	}

	// Token: 0x06014ABB RID: 84667 RVA: 0x005B9ADC File Offset: 0x005B7CDC
	private void SelectTab(int index, bool needRefresh = true)
	{
		for (int i = 0; i < this.TabIndex.Count; i++)
		{
			GenericLayout<RoleSkillBranchPopView.TeamTabItem, int> tabLayout = this.TabLayout;
			RoleSkillBranchPopView.TeamTabItem teamTabItem = (tabLayout != null) ? tabLayout.GetLayoutItemByIndex(i) : null;
			if (teamTabItem != null)
			{
				teamTabItem.SetIsSelected(i == index);
			}
		}
		if (needRefresh)
		{
			GenericLayout<RoleSkillBranchPopView.RoleSkillBranchPopViewRoleItem, RoleSkillBranchPopView.RoleData> roleLayout = this.RoleLayout;
			if (roleLayout == null)
			{
				return;
			}
			roleLayout.RefreshByData(this.TabData[index], null, false);
		}
	}

	// Token: 0x04009F66 RID: 40806
	protected static readonly IReadOnlyList<string> teamTabTextKey = new List<string>
	{
		"GhostShipTeamName_Text1",
		"GhostShipTeamName_Text2"
	};

	// Token: 0x04009F67 RID: 40807
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RoleSkillBranchPopView.RoleSkillBranchPopViewRoleItem, RoleSkillBranchPopView.RoleData> RoleLayout;

	// Token: 0x04009F68 RID: 40808
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<RoleSkillBranchPopView.TeamTabItem, int> TabLayout;

	// Token: 0x04009F69 RID: 40809
	private List<List<RoleSkillBranchPopView.RoleData>> TabData = new List<List<RoleSkillBranchPopView.RoleData>>();

	// Token: 0x04009F6A RID: 40810
	private List<int> TabIndex = new List<int>();

	// Token: 0x02008BF5 RID: 35829
	[NullableContext(0)]
	public class RoleData
	{
		// Token: 0x1700A85D RID: 43101
		// (get) Token: 0x06049732 RID: 300850 RVA: 0x013DA64B File Offset: 0x013D884B
		// (set) Token: 0x06049733 RID: 300851 RVA: 0x013DA653 File Offset: 0x013D8853
		public int RoleId { get; set; }

		// Token: 0x1700A85E RID: 43102
		// (get) Token: 0x06049734 RID: 300852 RVA: 0x013DA65C File Offset: 0x013D885C
		// (set) Token: 0x06049735 RID: 300853 RVA: 0x013DA664 File Offset: 0x013D8864
		public int SkillBranchIndex { get; set; } = -1;
	}

	// Token: 0x02008BF6 RID: 35830
	[NullableContext(0)]
	private enum EChild
	{
		// Token: 0x0402F260 RID: 193120
		TextTitle,
		// Token: 0x0402F261 RID: 193121
		PanelRoleList,
		// Token: 0x0402F262 RID: 193122
		ItemRole,
		// Token: 0x0402F263 RID: 193123
		ItemTextSingleTeam,
		// Token: 0x0402F264 RID: 193124
		PanelTeamTab,
		// Token: 0x0402F265 RID: 193125
		ItemTeamTab,
		// Token: 0x0402F266 RID: 193126
		ItemTextMultiTeam
	}

	// Token: 0x02008BF7 RID: 35831
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoleSkillBranchPopViewRoleItem : GridProxyAbstract<RoleSkillBranchPopView.RoleData>
	{
		// Token: 0x06049737 RID: 300855 RVA: 0x013DA67C File Offset: 0x013D887C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06049738 RID: 300856 RVA: 0x013DA7AC File Offset: 0x013D89AC
		protected override UniTask OnBeforeStartAsync()
		{
			RoleSkillBranchPopView.RoleSkillBranchPopViewRoleItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleSkillBranchPopView.RoleSkillBranchPopViewRoleItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06049739 RID: 300857 RVA: 0x013DA7F0 File Offset: 0x013D89F0
		public override void Refresh(RoleSkillBranchPopView.RoleData data, bool isSelected, int gridIndex)
		{
			this.RoleId = data.RoleId;
			UUIItem roleItem = base.GetItem(1);
			roleItem.SetAlpha(0f);
			USpineSkeletonAnimationComponent roleSpine = base.GetSpine(2);
			roleSpine.SetActive(this.RoleId > 0, false);
			if (this.RoleId <= 0)
			{
				roleItem.SetAlpha(0f);
				return;
			}
			int itemId = ModelBase<RoleSkinModel>.Instance.GetRoleSkinDataByRoleId(this.RoleId).ItemId;
			RoleSkin value = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(itemId).Value;
			string formationSpineAtlas = value.FormationSpineAtlas;
			string formationSpineSkeletonData = value.FormationSpineSkeletonData;
			Func<int, float> param = new Func<int, float>(value.SpineParam);
			base.SetSpineAssetByPath(formationSpineAtlas, formationSpineSkeletonData, roleSpine).ContinueWith(delegate()
			{
				roleSpine.SetAnimation(0, ESpineAnimation.Idle.ToString(), true);
				roleItem.SetAlpha(1f);
				roleItem.SetAnchorOffsetX(param(0));
				roleItem.SetAnchorOffsetY(param(1));
				roleItem.SetUIItemScale(new FVector(param(2), param(2), param(2)));
			});
			int roleSkillBranchIndexInCurrentGamePlay = ModelBase<RoleModel>.Instance.GetRoleSkillBranchIndexInCurrentGamePlay(this.RoleId);
			bool flag = roleSkillBranchIndexInCurrentGamePlay > -1;
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(!flag);
			}
			UUIItem item2 = base.GetItem(4);
			if (item2 != null)
			{
				item2.SetUIActive(flag);
			}
			if (!flag)
			{
				return;
			}
			RoleSkillBranchPopView.SkillBranchItem skillBranchItem = this.SkillBranchItem;
			if (skillBranchItem != null)
			{
				skillBranchItem.SetActiveBranchIndex(roleSkillBranchIndexInCurrentGamePlay);
			}
			RoleSkillBranchPopView.SkillBranchItem skillBranchItem2 = this.SkillBranchItem;
			if (skillBranchItem2 != null)
			{
				skillBranchItem2.RefreshIcon(new Func<int, string>(this.RefreshSkillBranchIconHandler));
			}
			int roleBranchIdByIndex = ModelBase<RoleModel>.Instance.GetRoleBranchIdByIndex(this.RoleId, roleSkillBranchIndexInCurrentGamePlay);
			SkillBranch? skillBranchConfigById = ConfigBase<RoleConfig>.Instance.GetSkillBranchConfigById(roleBranchIdByIndex);
			if (skillBranchConfigById == null)
			{
				return;
			}
			UUIText text = base.GetText(3);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, skillBranchConfigById.Value.Name, Array.Empty<object>());
		}

		// Token: 0x0604973A RID: 300858 RVA: 0x013DA9AC File Offset: 0x013D8BAC
		private string RefreshSkillBranchIconHandler(int index)
		{
			int roleBranchIdByIndex = ModelBase<RoleModel>.Instance.GetRoleBranchIdByIndex(this.RoleId, index);
			SkillBranch? skillBranchConfigById = ConfigBase<RoleConfig>.Instance.GetSkillBranchConfigById(roleBranchIdByIndex);
			if (skillBranchConfigById == null)
			{
				return string.Empty;
			}
			return skillBranchConfigById.Value.Icon;
		}

		// Token: 0x0604973B RID: 300859 RVA: 0x013DA9F8 File Offset: 0x013D8BF8
		private void SwitchSkillBranchHandler(int branchIndex)
		{
			int roleBranchIdByIndex = ModelBase<RoleModel>.Instance.GetRoleBranchIdByIndex(this.RoleId, branchIndex);
			SkillBranch? skillBranchConfigById = ConfigBase<RoleConfig>.Instance.GetSkillBranchConfigById(roleBranchIdByIndex);
			if (skillBranchConfigById == null)
			{
				return;
			}
			ControllerBase<RoleController>.Instance.ModifyRoleSkillBranchInCurrentGamePlay(this.RoleId, roleBranchIdByIndex, true);
			UUIText text = base.GetText(3);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, skillBranchConfigById.Value.Name, Array.Empty<object>());
		}

		// Token: 0x0402F267 RID: 193127
		private int RoleId;

		// Token: 0x0402F268 RID: 193128
		[Nullable(2)]
		private RoleSkillBranchPopView.SkillBranchItem SkillBranchItem;

		// Token: 0x0200CDF1 RID: 52721
		[NullableContext(0)]
		private enum EChild
		{
			// Token: 0x0403F7EE RID: 260078
			ItemBtn,
			// Token: 0x0403F7EF RID: 260079
			RoleItem,
			// Token: 0x0403F7F0 RID: 260080
			RoleSpine,
			// Token: 0x0403F7F1 RID: 260081
			TextBranchName,
			// Token: 0x0403F7F2 RID: 260082
			PanelSkillBranch,
			// Token: 0x0403F7F3 RID: 260083
			PanelLock,
			// Token: 0x0403F7F4 RID: 260084
			TextLock,
			// Token: 0x0403F7F5 RID: 260085
			PanelSkillBranchItem
		}
	}

	// Token: 0x02008BF8 RID: 35832
	[NullableContext(0)]
	public class TeamTabItem : GridProxyAbstract<int>
	{
		// Token: 0x0604973D RID: 300861 RVA: 0x013DAA70 File Offset: 0x013D8C70
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleStateChange));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604973E RID: 300862 RVA: 0x013DAB16 File Offset: 0x013D8D16
		private void OnToggleStateChange(EToggleState state)
		{
			if (state != EToggleState.ETT_Checked)
			{
				return;
			}
			Action<int> selectHandler = this.SelectHandler;
			if (selectHandler == null)
			{
				return;
			}
			selectHandler(base.GridIndex);
		}

		// Token: 0x0604973F RID: 300863 RVA: 0x013DAB35 File Offset: 0x013D8D35
		public void SetIsSelected(bool isSelected)
		{
			base.GetExtendToggle(0).SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x06049740 RID: 300864 RVA: 0x013DAB50 File Offset: 0x013D8D50
		public override void Refresh(int index, bool isSelected, int gridIndex)
		{
			UUIText text = base.GetText(1);
			string text2 = (index >= 0 && index < RoleSkillBranchPopView.teamTabTextKey.Count) ? RoleSkillBranchPopView.teamTabTextKey[index] : null;
			if (string.IsNullOrEmpty(text2))
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, text2, Array.Empty<object>());
		}

		// Token: 0x0402F269 RID: 193129
		[Nullable(2)]
		public Action<int> SelectHandler;

		// Token: 0x0200CDF4 RID: 52724
		private enum EChild
		{
			// Token: 0x0403F7FE RID: 260094
			Toggle,
			// Token: 0x0403F7FF RID: 260095
			TextName
		}
	}

	// Token: 0x02008BF9 RID: 35833
	[NullableContext(0)]
	public class SkillBranchItem : CommonRoleSkillBranchSwitchItem
	{
		// Token: 0x06049742 RID: 300866 RVA: 0x013DABA8 File Offset: 0x013D8DA8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(base.OnToggleStateChange));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06049743 RID: 300867 RVA: 0x013DACD4 File Offset: 0x013D8ED4
		[NullableContext(1)]
		protected override SkillBranchSwitchItemGroup[] CollectBranchItems()
		{
			return new SkillBranchSwitchItemGroup[]
			{
				new SkillBranchSwitchItemGroup
				{
					SpriteTagIcon = base.GetSprite(2),
					ActiveIndexHandler = delegate(bool active)
					{
						base.GetItem(3).SetUIActive(active);
						this.SetMiddleIconToLeft(active);
					}
				},
				new SkillBranchSwitchItemGroup
				{
					SpriteTagIcon = base.GetSprite(4),
					ActiveIndexHandler = delegate(bool active)
					{
						base.GetItem(5).SetUIActive(active);
					}
				}
			};
		}

		// Token: 0x06049744 RID: 300868 RVA: 0x013DAD35 File Offset: 0x013D8F35
		[NullableContext(1)]
		protected override UUIExtendToggle GetBranchToggle()
		{
			return base.GetExtendToggle(0);
		}

		// Token: 0x06049745 RID: 300869 RVA: 0x013DAD40 File Offset: 0x013D8F40
		private void SetMiddleIconToLeft(bool isLeft)
		{
			UUIItem item = base.GetItem(1);
			FVector fvector = new FVector(0f, (float)(isLeft ? 0 : 180), 0f);
			FRotator frotator = FRotator.MakeFromEuler(fvector);
			item.SetUIRelativeRotation(frotator);
		}

		// Token: 0x0200CDF5 RID: 52725
		private enum EChild
		{
			// Token: 0x0403F801 RID: 260097
			Toggle,
			// Token: 0x0403F802 RID: 260098
			ItemSpriteMiddle,
			// Token: 0x0403F803 RID: 260099
			SpriteTagIconL,
			// Token: 0x0403F804 RID: 260100
			ItemTagL,
			// Token: 0x0403F805 RID: 260101
			SpriteTagIconR,
			// Token: 0x0403F806 RID: 260102
			ItemTagR
		}
	}
}
