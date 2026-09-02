using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005982 RID: 22914
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRoguePanelRole : UiPanelBase
	{
		// Token: 0x0603A0D1 RID: 237777 RVA: 0x00EB1838 File Offset: 0x00EAFA38
		public MapRoguePanelRole(MapRogueGameInfo gameInfo)
		{
			this.GameInfo = gameInfo;
		}

		// Token: 0x0603A0D2 RID: 237778 RVA: 0x00EB188C File Offset: 0x00EAFA8C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(USpineSkeletonAnimationComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(USpineSkeletonAnimationComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x0603A0D3 RID: 237779 RVA: 0x00EB1940 File Offset: 0x00EAFB40
		protected override UniTask OnBeforeStartAsync()
		{
			MapRoguePanelRole.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MapRoguePanelRole.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A0D4 RID: 237780 RVA: 0x00EB1983 File Offset: 0x00EAFB83
		public void OnTick(float delta)
		{
			if (base.IsShow)
			{
				ListSliderControl<RogueGetListItem> listSliderControl = this.ListSliderControl;
				if (listSliderControl == null)
				{
					return;
				}
				listSliderControl.Tick(delta);
			}
		}

		// Token: 0x0603A0D5 RID: 237781 RVA: 0x00EB19A0 File Offset: 0x00EAFBA0
		private UniTask InitRole()
		{
			MapRoguePanelRole.<InitRole>d__13 <InitRole>d__;
			<InitRole>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRole>d__.<>4__this = this;
			<InitRole>d__.<>1__state = -1;
			<InitRole>d__.<>t__builder.Start<MapRoguePanelRole.<InitRole>d__13>(ref <InitRole>d__);
			return <InitRole>d__.<>t__builder.Task;
		}

		// Token: 0x0603A0D6 RID: 237782 RVA: 0x00EB19E3 File Offset: 0x00EAFBE3
		public void SetRoleDirection(bool directionRight)
		{
			this.DirectionRight = directionRight;
			base.GetItem(4).SetUIActive(!directionRight);
			base.GetItem(6).SetUIActive(directionRight);
		}

		// Token: 0x0603A0D7 RID: 237783 RVA: 0x00EB1A0C File Offset: 0x00EAFC0C
		public void SetRoleAnim(EMapRogueSpineAnim anim, bool loop = true)
		{
			MapRoguePanelRole.<>c__DisplayClass15_0 CS$<>8__locals1 = new MapRoguePanelRole.<>c__DisplayClass15_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.trackEntryL = base.GetSpine(3).SetAnimation(0, anim.ToEnumString(), loop);
			CS$<>8__locals1.trackEntryR = base.GetSpine(5).SetAnimation(0, anim.ToEnumString(), loop);
			if (!loop)
			{
				CS$<>8__locals1.trackEntryL.AnimationComplete.Add(new Action<UTrackEntry>(CS$<>8__locals1.<SetRoleAnim>g__back2Idle|0));
				CS$<>8__locals1.trackEntryR.AnimationComplete.Add(new Action<UTrackEntry>(CS$<>8__locals1.<SetRoleAnim>g__back2Idle|0));
			}
		}

		// Token: 0x0603A0D8 RID: 237784 RVA: 0x00EB1A95 File Offset: 0x00EAFC95
		public void SetRolePosItemVisible(bool bVisible)
		{
			base.GetItem(0).SetUIActive(bVisible);
		}

		// Token: 0x0603A0D9 RID: 237785 RVA: 0x00EB1AA4 File Offset: 0x00EAFCA4
		public void SetListRootItem(global::Vector scaleVector)
		{
			base.GetVerticalLayout(1).RootUIComp.Get().SetUIItemScale(scaleVector.ToUeVectorOld());
		}

		// Token: 0x0603A0DA RID: 237786 RVA: 0x00EB1AD0 File Offset: 0x00EAFCD0
		private void InitListSlider()
		{
			this.ListSliderControl = new ListSliderControl<RogueGetListItem>(new ListSliderControlData<RogueGetListItem>(base.GetItem(2).GetParentAsUIItem(), new Func<RogueGetListItem>(this.CreateProxyFunction), new Func<bool>(this.CheckNext))
			{
				ChildTemplate = base.GetItem(2),
				MaxShowCount = new int?(this.ListMaxCount),
				AddItemTime = new float?(this.ListAddItemTime),
				TickMode = new ETickItemMode?(ETickItemMode.TickOnlyTop),
				ItemShowTime = ConfigCommonParamById.GetFloatConfig("MapRogueGetListShowTime"),
				ItemSliderTime = ConfigCommonParamById.GetFloatConfig("MapRogueGetListSilderTime")
			});
			this.ListSliderControl.DisEnableParentLayout();
		}

		// Token: 0x0603A0DB RID: 237787 RVA: 0x00EB1B79 File Offset: 0x00EAFD79
		private RogueGetListItem CreateProxyFunction()
		{
			return new RogueGetListItem();
		}

		// Token: 0x0603A0DC RID: 237788 RVA: 0x00EB1B80 File Offset: 0x00EAFD80
		private bool CheckNext()
		{
			return !this.GameInfo.IsGetItemDataEmpty();
		}

		// Token: 0x04020ED5 RID: 134869
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected ListSliderControl<RogueGetListItem> ListSliderControl;

		// Token: 0x04020ED6 RID: 134870
		private readonly int ListMaxCount = ConfigCommonParamById.GetIntConfig("MapRogueGetListMaxCount").GetValueOrDefault(1);

		// Token: 0x04020ED7 RID: 134871
		private readonly float ListAddItemTime = ConfigCommonParamById.GetFloatConfig("MapRogueGetListIntervalTime").GetValueOrDefault();

		// Token: 0x04020ED8 RID: 134872
		private const string MALE_L_SPINE_ATLAS = "/Game/Aki/UI/UIResources/Common/Spine/RogueNanzhu/Avatar_HeroL/Avatar_HeroL.Avatar_HeroL-atlas";

		// Token: 0x04020ED9 RID: 134873
		private const string MALE_L_SPINE_SKELETON = "/Game/Aki/UI/UIResources/Common/Spine/RogueNanzhu/Avatar_HeroL/Avatar_HeroL.Avatar_HeroL-data";

		// Token: 0x04020EDA RID: 134874
		private const string MALE_R_SPINE_ATLAS = "/Game/Aki/UI/UIResources/Common/Spine/RogueNanzhu/Avatar_HeroR/Avatar_HeroR.Avatar_HeroR-atlas";

		// Token: 0x04020EDB RID: 134875
		private const string MALE_R_SPINE_SKELETON = "/Game/Aki/UI/UIResources/Common/Spine/RogueNanzhu/Avatar_HeroR/Avatar_HeroR.Avatar_HeroR-data";

		// Token: 0x04020EDC RID: 134876
		protected MapRogueGameInfo GameInfo;

		// Token: 0x04020EDD RID: 134877
		protected bool DirectionRight = true;
	}
}
