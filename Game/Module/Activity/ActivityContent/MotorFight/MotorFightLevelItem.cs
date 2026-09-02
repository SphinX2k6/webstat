using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066D9 RID: 26329
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MotorFightLevelItem : GridProxyAbstract<MotorFightLevelData>
	{
		// Token: 0x06041BD4 RID: 269268 RVA: 0x010DBC24 File Offset: 0x010D9E24
		protected unsafe override void OnRegisterComponent()
		{
			int num = 19;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041BD5 RID: 269269 RVA: 0x010DBF06 File Offset: 0x010DA106
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x06041BD6 RID: 269270 RVA: 0x010DBF1C File Offset: 0x010DA11C
		[NullableContext(1)]
		public override void Refresh(MotorFightLevelData data, bool isSelected, int gridIndex)
		{
			this.LevelData = data;
			EMotorFightLevelType id = data.IsUnLock ? data.Type : EMotorFightLevelType.Lock;
			MotorFightLevelType? motorFightLevelType = ConfigBase<MotorFightConfig>.Instance.GetMotorFightLevelType((int)id);
			base.SetTextureByPath(motorFightLevelType.Value.Hold, base.GetTexture(1), null, null);
			base.SetTextureByPath(motorFightLevelType.Value.Mask, base.GetTexture(2), null, null);
			base.SetTextureByPath(motorFightLevelType.Value.Light, base.GetTexture(3), null, null);
			base.SetTextureByPath(motorFightLevelType.Value.Bg, base.GetTexture(4), null, null);
			base.SetTextureByPath(motorFightLevelType.Value.Title, base.GetTexture(6), null, null);
			string path = data.IsUnLock ? data.LevelTexture : "/Game/Aki/UI/UIResources/UiActivity/Image/Activity31/MotorcycleBattle/Level/T_MotorcycleLevelLock.T_MotorcycleLevelLock";
			base.SetTextureByPath(path, base.GetTexture(5), null, null);
			bool flag = data.Type == EMotorFightLevelType.Endless;
			UUIArtText artText = base.GetArtText(7);
			if (artText != null)
			{
				artText.SetUIActive(!flag);
			}
			UUIArtText artText2 = base.GetArtText(7);
			if (artText2 != null)
			{
				artText2.SetText(data.Number);
			}
			UUISprite sprite = base.GetSprite(8);
			if (sprite != null)
			{
				sprite.SetUIActive(flag);
			}
			UUIItem item = base.GetItem(9);
			if (item != null)
			{
				item.SetUIActive(!data.IsUnLock);
			}
			UUIItem item2 = base.GetItem(10);
			if (item2 != null)
			{
				item2.SetUIActive(data.HasLevelRedDot);
			}
			UUIItem item3 = base.GetItem(11);
			if (item3 != null)
			{
				item3.SetUIActive(!flag && data.IsFinished);
			}
			UUITexture texture = base.GetTexture(12);
			if (texture != null)
			{
				texture.SetUIActive(false);
			}
			UUITexture texture2 = base.GetTexture(14);
			if (texture2 != null)
			{
				texture2.SetUIActive(false);
			}
			UUITexture texture3 = base.GetTexture(13);
			if (texture3 != null)
			{
				texture3.SetUIActive(false);
			}
			UUIItem item4 = base.GetItem(16);
			if (item4 != null)
			{
				item4.SetUIActive(flag && data.IsUnLock);
			}
			this.PlaySequence();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(17), "MotorFightGame_LevelBestScore", new <>z__ReadOnlySingleElementList<object>(data.BestScore));
			this.RefreshUnlockText();
			if (data.PreMotorFightLevelData != null)
			{
				int offset = data.Row - data.PreMotorFightLevelData.Row;
				int index = this.GetIndex(offset);
				UUITexture texture4 = base.GetTexture(index);
				if (texture4 != null)
				{
					texture4.SetUIActive(true);
				}
			}
			if (this.LevelData != null && !this.LevelData.IsUnLock)
			{
				this.AddTimer();
				return;
			}
			this.RemoveTimer();
		}

		// Token: 0x06041BD7 RID: 269271 RVA: 0x010DC1D0 File Offset: 0x010DA3D0
		private void RefreshUnlockText()
		{
			if (!this.LevelData.IsUnLock)
			{
				if (!this.LevelData.IsReachUnlockTime())
				{
					string localTextNew = ConfigMultiTextLang.GetLocalTextNew("MotorFightGame_LevelCondition_02", null);
					string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.LevelData.UnlockTime, localTextNew);
					UUIText text = base.GetText(15);
					if (text == null)
					{
						return;
					}
					text.SetText(remainTimeText, true);
					return;
				}
				else
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), "MotorFightGame_LevelCondition_01", Array.Empty<object>());
				}
			}
		}

		// Token: 0x06041BD8 RID: 269272 RVA: 0x010DC24B File Offset: 0x010DA44B
		private int GetIndex(int offset)
		{
			if (offset == 0)
			{
				return 12;
			}
			if (offset == -1)
			{
				return 13;
			}
			return 14;
		}

		// Token: 0x06041BD9 RID: 269273 RVA: 0x010DC25C File Offset: 0x010DA45C
		private void PlaySequence()
		{
			if (this.LevelData.HasLevelRedDot || this.LevelData.IsFinished)
			{
				string sequenceName = this.LevelData.HasLevelRedDot ? "NewLevel" : "Complete";
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer == null)
				{
					return;
				}
				levelSequencePlayer.PlayLevelSequenceByName(sequenceName, false, null, false);
			}
		}

		// Token: 0x06041BDA RID: 269274 RVA: 0x010DC2B9 File Offset: 0x010DA4B9
		private void UpdateUnlock()
		{
			if (this.LevelData != null && this.LevelData.IsUnLock)
			{
				this.Refresh(this.LevelData, false, 0);
			}
		}

		// Token: 0x06041BDB RID: 269275 RVA: 0x010DC2DE File Offset: 0x010DA4DE
		private void AddTimer()
		{
			this.RemoveTimer();
			this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
			{
				this.RefreshUnlockText();
				this.UpdateUnlock();
			}, (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
		}

		// Token: 0x06041BDC RID: 269276 RVA: 0x010DC315 File Offset: 0x010DA515
		private void RemoveTimer()
		{
			if (this.TimerHandle != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
		}

		// Token: 0x06041BDD RID: 269277 RVA: 0x010DC337 File Offset: 0x010DA537
		protected override void OnBeforeDestroy()
		{
			if (this.LevelSequencePlayer != null)
			{
				this.LevelSequencePlayer.Clear();
				this.LevelSequencePlayer = null;
			}
		}

		// Token: 0x06041BDE RID: 269278 RVA: 0x010DC354 File Offset: 0x010DA554
		private void OnButtonClick()
		{
			if (!this.LevelData.IsUnLock)
			{
				if (!this.LevelData.IsReachUnlockTime())
				{
					string localTextNew = ConfigMultiTextLang.GetLocalTextNew("MotorFightGame_LevelCondition_02", null);
					string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.LevelData.UnlockTime, localTextNew);
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(remainTimeText);
					return;
				}
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("MotorFightGame_LevelCondition_01", Array.Empty<object>());
				return;
			}
			else
			{
				MotorFightActivityData motorFightActivityData = ControllerBase<MotorFightController>.Instance.GetMotorFightActivityData();
				if (motorFightActivityData.HasLastSavedLevelData())
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorFightArchiveTip, this.LevelData.Id, null);
					return;
				}
				MotorFightLevelDetailViewModel param = new MotorFightLevelDetailViewModel(motorFightActivityData, this.LevelData);
				Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorFightLevelDetailView, param, null);
				if (this.LevelData.HasLevelRedDot)
				{
					this.LevelData.ReadLevelRedDot();
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.LevelData.ActivityId);
				}
				UUIItem item = base.GetItem(10);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(false);
				return;
			}
		}

		// Token: 0x06041BDF RID: 269279 RVA: 0x010DC457 File Offset: 0x010DA657
		public UUIItem GetNavigationItem()
		{
			return base.GetItem(18);
		}

		// Token: 0x04024AE2 RID: 150242
		[Nullable(1)]
		public const string MOTOR_FIGHT_LOCK_LEVEL_TEXTURE_PATH = "/Game/Aki/UI/UIResources/UiActivity/Image/Activity31/MotorcycleBattle/Level/T_MotorcycleLevelLock.T_MotorcycleLevelLock";

		// Token: 0x04024AE3 RID: 150243
		private MotorFightLevelData LevelData;

		// Token: 0x04024AE4 RID: 150244
		private TimerHandle TimerHandle;

		// Token: 0x04024AE5 RID: 150245
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200C708 RID: 50952
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403D466 RID: 250982
			public const int BtnRoot = 0;

			// Token: 0x0403D467 RID: 250983
			public const int TextureHold = 1;

			// Token: 0x0403D468 RID: 250984
			public const int TextureMask = 2;

			// Token: 0x0403D469 RID: 250985
			public const int TextureLight = 3;

			// Token: 0x0403D46A RID: 250986
			public const int TextureBg = 4;

			// Token: 0x0403D46B RID: 250987
			public const int TextureLevel = 5;

			// Token: 0x0403D46C RID: 250988
			public const int TextureTitle = 6;

			// Token: 0x0403D46D RID: 250989
			public const int ArtText = 7;

			// Token: 0x0403D46E RID: 250990
			public const int SpriteEndLess = 8;

			// Token: 0x0403D46F RID: 250991
			public const int ItemLockPanel = 9;

			// Token: 0x0403D470 RID: 250992
			public const int ItemNewPanel = 10;

			// Token: 0x0403D471 RID: 250993
			public const int ItemFinishPanel = 11;

			// Token: 0x0403D472 RID: 250994
			public const int TextureLineCenter = 12;

			// Token: 0x0403D473 RID: 250995
			public const int TextureLineDown = 13;

			// Token: 0x0403D474 RID: 250996
			public const int TextureLineUp = 14;

			// Token: 0x0403D475 RID: 250997
			public const int TextUnlock = 15;

			// Token: 0x0403D476 RID: 250998
			public const int ItemBestScorePanel = 16;

			// Token: 0x0403D477 RID: 250999
			public const int TextBestScore = 17;

			// Token: 0x0403D478 RID: 251000
			public const int ItemNavigation = 18;
		}
	}
}
