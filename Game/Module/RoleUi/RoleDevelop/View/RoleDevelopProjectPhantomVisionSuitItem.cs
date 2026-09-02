using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050BE RID: 20670
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoleDevelopProjectPhantomVisionSuitItem : GridProxyAbstract<RoleDevelopPhantomVisionSuitItemData>
	{
		// Token: 0x06035413 RID: 218131 RVA: 0x00D5A174 File Offset: 0x00D58374
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
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
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035414 RID: 218132 RVA: 0x00D5A32C File Offset: 0x00D5852C
		protected override UniTask OnBeforeStartAsync()
		{
			RoleDevelopProjectPhantomVisionSuitItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleDevelopProjectPhantomVisionSuitItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035415 RID: 218133 RVA: 0x00D5A370 File Offset: 0x00D58570
		private UniTask InitButtonItem()
		{
			RoleDevelopProjectPhantomVisionSuitItem.<InitButtonItem>d__7 <InitButtonItem>d__;
			<InitButtonItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitButtonItem>d__.<>4__this = this;
			<InitButtonItem>d__.<>1__state = -1;
			<InitButtonItem>d__.<>t__builder.Start<RoleDevelopProjectPhantomVisionSuitItem.<InitButtonItem>d__7>(ref <InitButtonItem>d__);
			return <InitButtonItem>d__.<>t__builder.Task;
		}

		// Token: 0x06035416 RID: 218134 RVA: 0x00D5A3B4 File Offset: 0x00D585B4
		private UniTask InitItemBaseCurrentVision()
		{
			RoleDevelopProjectPhantomVisionSuitItem.<InitItemBaseCurrentVision>d__8 <InitItemBaseCurrentVision>d__;
			<InitItemBaseCurrentVision>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitItemBaseCurrentVision>d__.<>4__this = this;
			<InitItemBaseCurrentVision>d__.<>1__state = -1;
			<InitItemBaseCurrentVision>d__.<>t__builder.Start<RoleDevelopProjectPhantomVisionSuitItem.<InitItemBaseCurrentVision>d__8>(ref <InitItemBaseCurrentVision>d__);
			return <InitItemBaseCurrentVision>d__.<>t__builder.Task;
		}

		// Token: 0x06035417 RID: 218135 RVA: 0x00D5A3F8 File Offset: 0x00D585F8
		public override void Refresh(RoleDevelopPhantomVisionSuitItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.ButtonConfirm.SetLocalTextNew(data.ButtonName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.Name, Array.Empty<object>());
			if (data.ItemType == EPhantomSuitItemType.Dungeon)
			{
				base.GetSprite(4).SetUIActive(false);
				base.GetTexture(5).SetUIActive(true);
				base.SetTextureByPath(data.TypeIcon, base.GetTexture(5), null, null);
				this.RefreshNightMareDesc(data.DungeonId);
				this.RefreshDoubleIcon(data.DungeonId);
				base.GetItem(8).SetUIActive(true);
				base.GetItem(9).SetUIActive(false);
			}
			else if (data.ItemType == EPhantomSuitItemType.Phantom)
			{
				base.GetSprite(4).SetUIActive(true);
				base.GetTexture(5).SetUIActive(false);
				UUIText text = base.GetText(6);
				if (text != null)
				{
					text.SetUIActive(false);
				}
				base.GetItem(7).SetUIActive(false);
				base.GetItem(8).SetUIActive(false);
				base.GetItem(9).SetUIActive(true);
				this.ItemBaseCurrentVision.Refresh(new RoleDevelopPhantomVisionSuitListItemData
				{
					MonsterData = data.MonsterDataList[0]
				}, false, 0);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), data.Name, Array.Empty<object>());
			}
			List<RoleDevelopPhantomVisionSuitListItemData> list = new List<RoleDevelopPhantomVisionSuitListItemData>();
			if (data.RewardDataList != null)
			{
				foreach (DropRewardItemData rewardData in data.RewardDataList)
				{
					list.Add(new RoleDevelopPhantomVisionSuitListItemData
					{
						RewardData = rewardData
					});
				}
			}
			this.ItemLayout.RefreshByData(list, null, false);
		}

		// Token: 0x06035418 RID: 218136 RVA: 0x00D5A5C4 File Offset: 0x00D587C4
		private RoleDevelopProjectPhantomVisionSuitListItem CreateItem()
		{
			return new RoleDevelopProjectPhantomVisionSuitListItem();
		}

		// Token: 0x06035419 RID: 218137 RVA: 0x00D5A5CC File Offset: 0x00D587CC
		private void OnClickConfirm(int value)
		{
			if (this.Data == null)
			{
				return;
			}
			if (this.Data.ItemType == EPhantomSuitItemType.Phantom)
			{
				ControllerBase<CalabashController>.Instance.JumpToCalabashCollectTabView(this.Data.MonsterDataList[0].MonsterId);
			}
			else
			{
				this.JumpToDungeon(this.Data.DungeonId);
			}
			if (this.Data.LogRoleId != null && this.Data.LogMainPage != null && this.Data.LogSubPage != null)
			{
				ControllerBase<RoleController>.Instance.LogRoleDevelopClick(this.Data.LogRoleId.Value, this.Data.LogMainPage.Value, this.Data.LogSubPage.Value, null);
			}
		}

		// Token: 0x0603541A RID: 218138 RVA: 0x00D5A6B0 File Offset: 0x00D588B0
		private void JumpToDungeon(int dungeonId)
		{
			if (ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("DungeonDetection", Array.Empty<object>());
				return;
			}
			SilentAreaDetectionRecord silentAreaDetectData = ModelBase<AdventureGuideModel>.Instance.GetSilentAreaDetectData(dungeonId);
			if (silentAreaDetectData == null)
			{
				return;
			}
			if (ModelBase<AdventureGuideModel>.Instance.TryAdventureJumpBySilent(silentAreaDetectData))
			{
				return;
			}
			if (silentAreaDetectData.Conf.JumpType == 2)
			{
				ModelBase<AdventureGuideModel>.Instance.SetFromManualDetect(true);
				ControllerBase<AdventureGuideController>.Instance.RequestForDetection(DetectionType.SilentArea, silentAreaDetectData.Conf.LevelPlayList(), dungeonId);
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("TeleportMarkNotUnlock", Array.Empty<object>());
				return;
			}
			if (!ControllerBase<AdventureGuideController>.Instance.IsMarkUnlock(silentAreaDetectData.Conf.MarkId))
			{
				return;
			}
			ModelBase<AdventureGuideModel>.Instance.SetFromManualDetect(true);
			ControllerBase<AdventureGuideController>.Instance.RequestForDetection(DetectionType.SilentArea, silentAreaDetectData.Conf.LevelPlayList(), dungeonId);
		}

		// Token: 0x0603541B RID: 218139 RVA: 0x00D5A788 File Offset: 0x00D58988
		private void RefreshDoubleIcon(int dungeonId)
		{
			SilentAreaDetectionRecord silentAreaDetectData = ModelBase<AdventureGuideModel>.Instance.GetSilentAreaDetectData(dungeonId);
			bool uiactive = silentAreaDetectData != null && RoleDevelopUtil.IsDungeonShowDouble((EDungeonType)silentAreaDetectData.Conf.Secondary);
			base.GetItem(7).SetUIActive(uiactive);
		}

		// Token: 0x0603541C RID: 218140 RVA: 0x00D5A7C8 File Offset: 0x00D589C8
		private void RefreshNightMareDesc(int dungeonId)
		{
			UUIText text = base.GetText(6);
			SilentAreaDetectionRecord silentAreaDetectData = ModelBase<AdventureGuideModel>.Instance.GetSilentAreaDetectData(dungeonId);
			if (silentAreaDetectData == null || (silentAreaDetectData.Conf.Secondary != 63 && silentAreaDetectData.Conf.Secondary != 64))
			{
				if (text != null)
				{
					text.SetUIActive(false);
				}
				return;
			}
			AdventureGuideModel instance = ModelBase<AdventureGuideModel>.Instance;
			ValueTuple<long, int> valueTuple;
			if (instance.GetIsDetectionPreOpenByRecord(silentAreaDetectData))
			{
				valueTuple = instance.GetNightMarePreOpenTarget(instance.GetPreOpenDetectionConf(silentAreaDetectData.Conf.Id, ESoundAreaDataType.SilentArea, silentAreaDetectData.Conf.PreOpenId).Value.InstanceID);
			}
			else
			{
				int[] array = silentAreaDetectData.Conf.LevelPlayList();
				ValueTuple<int, int> nightMareTarget = instance.GetNightMareTarget(new int?(silentAreaDetectData.Conf.MapId), (array != null && array.Length != 0) ? new int?(array[0]) : null);
				valueTuple = new ValueTuple<long, int>((long)nightMareTarget.Item1, nightMareTarget.Item2);
			}
			if (valueTuple.Item2 < 0)
			{
				if (text != null)
				{
					text.SetUIActive(false);
					return;
				}
			}
			else
			{
				if (text != null)
				{
					text.SetUIActive(true);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "NightMareLeftTimes", new <>z__ReadOnlyArray<object>(new object[]
				{
					valueTuple.Item1,
					valueTuple.Item2
				}));
			}
		}

		// Token: 0x0401EA41 RID: 125505
		[Nullable(2)]
		private RoleDevelopPhantomVisionSuitItemData Data;

		// Token: 0x0401EA42 RID: 125506
		private ButtonItem ButtonConfirm;

		// Token: 0x0401EA43 RID: 125507
		private GenericLayout<RoleDevelopProjectPhantomVisionSuitListItem, RoleDevelopPhantomVisionSuitListItemData> ItemLayout;

		// Token: 0x0401EA44 RID: 125508
		[Nullable(2)]
		private RoleDevelopProjectPhantomVisionSuitListItem ItemBaseCurrentVision;

		// Token: 0x0200B04C RID: 45132
		[NullableContext(0)]
		public static class EComponentType
		{
			// Token: 0x04036B18 RID: 224024
			public const int TxtName = 0;

			// Token: 0x04036B19 RID: 224025
			public const int PanelDetailLayout = 1;

			// Token: 0x04036B1A RID: 224026
			public const int ItemBase = 2;

			// Token: 0x04036B1B RID: 224027
			public const int BtnConfirm = 3;

			// Token: 0x04036B1C RID: 224028
			public const int IconSprite = 4;

			// Token: 0x04036B1D RID: 224029
			public const int IconTexture = 5;

			// Token: 0x04036B1E RID: 224030
			public const int TxtDesc = 6;

			// Token: 0x04036B1F RID: 224031
			public const int ItemDouble = 7;

			// Token: 0x04036B20 RID: 224032
			public const int PnlNormal = 8;

			// Token: 0x04036B21 RID: 224033
			public const int PnlCurrentVision = 9;

			// Token: 0x04036B22 RID: 224034
			public const int ItemBaseCurrentVision = 10;

			// Token: 0x04036B23 RID: 224035
			public const int TextNameCurrentVision = 11;
		}
	}
}
