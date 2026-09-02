using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.BossPiling.View.Item
{
	// Token: 0x02005F02 RID: 24322
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class BossPilingBossTabItem : GridProxyAbstract<BossPilingLevelInfo>
	{
		// Token: 0x0603D192 RID: 250258 RVA: 0x00F84B48 File Offset: 0x00F82D48
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D193 RID: 250259 RVA: 0x00F84CE0 File Offset: 0x00F82EE0
		protected override void OnStart()
		{
			base.GetExtendToggle(0).OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChange));
			base.GetExtendToggle(0).OnUndeterminedClicked.Add(new Action(this.OnUndeterminedClickToggle));
			this.Layout = new GenericLayout<BossPilingBossAchievementStar, bool>(base.GetHorizontalLayout(2), new Func<BossPilingBossAchievementStar>(this.CreateStar), null, false, true);
		}

		// Token: 0x0603D194 RID: 250260 RVA: 0x00F84D48 File Offset: 0x00F82F48
		protected override void OnBeforeDestroy()
		{
			base.GetExtendToggle(0).OnStateChange.Remove(new Action<EToggleState>(this.OnToggleStateChange));
			base.GetExtendToggle(0).OnUndeterminedClicked.Remove(new Action(this.OnUndeterminedClickToggle));
		}

		// Token: 0x0603D195 RID: 250261 RVA: 0x00F84D84 File Offset: 0x00F82F84
		public override void Refresh(BossPilingLevelInfo data, bool isSelected, int gridIndex)
		{
			this.CurrentData = data;
			this.UpdateInfo(false);
		}

		// Token: 0x0603D196 RID: 250262 RVA: 0x00F84D94 File Offset: 0x00F82F94
		public bool OnTick()
		{
			if (this.CurrentData == null)
			{
				return false;
			}
			if (this.CurrentData.IsUnlock)
			{
				return false;
			}
			if (this.CheckIsUnlock())
			{
				this.UpdateInfo(true);
				return false;
			}
			this.RefreshRemainTime();
			return true;
		}

		// Token: 0x0603D197 RID: 250263 RVA: 0x00F84DC8 File Offset: 0x00F82FC8
		protected void UpdateInfo(bool isUnlock = false)
		{
			bool flag = this.CurrentData.Id != this.CurrentId;
			this.CurrentId = this.CurrentData.Id;
			BossPilingLevels value = ConfigBase<BossPilingConfig>.Instance.GetLevelInfo(this.CurrentId).Value;
			bool flag2 = this.CheckIsUnlock();
			UUIItem item = base.GetItem(9);
			if (item != null)
			{
				item.SetUIActive(!flag2);
			}
			UUIItem item2 = base.GetItem(8);
			if (item2 != null)
			{
				item2.SetUIActive(flag2);
			}
			UUISprite sprite = base.GetSprite(7);
			if (sprite != null)
			{
				sprite.SetUIActive(flag2);
			}
			if (flag2)
			{
				UUIText text = base.GetText(1);
				if (text != null)
				{
					text.ShowTextNew(value.LevelName);
				}
				BossPilingActivityData activityData = ModelBase<BossPilingModel>.Instance.GetActivityData();
				List<int> starAchievement = activityData.GetStarAchievement(this.CurrentId);
				if (flag || isUnlock)
				{
					List<bool> list = new List<bool>();
					for (int i = 0; i < starAchievement[1]; i++)
					{
						list.Add(i < starAchievement[0]);
					}
					this.Layout.RefreshByData(list, null, true);
				}
				bool flag3 = this.IsSelectOnCb != null && this.IsSelectOnCb(this.CurrentId);
				if (flag3)
				{
					activityData.ClearLevelRedDotById(this.CurrentData.Id);
				}
				UUIItem item3 = base.GetItem(6);
				if (item3 != null)
				{
					item3.SetUIActive(activityData.CheckLevelRedDotById(this.CurrentData.Id));
				}
				this.SetSelected(flag3, false);
				base.SetTextureByPath(value.ToggleUnlock, base.GetTexture(5), null, null);
				string valueOrDefault = BossPilingDefine.BossPilingScoreTexMap.GetValueOrDefault(starAchievement[0]);
				UUISprite sprite2 = base.GetSprite(4);
				if (sprite2 != null)
				{
					sprite2.SetUIActive(valueOrDefault != null);
				}
				if (valueOrDefault != null)
				{
					string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(valueOrDefault);
					this.SetSpriteByPath(resourcePath, base.GetSprite(4), false, null, null);
				}
				return;
			}
			this.RefreshRemainTime();
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnDetermined, false, false, false);
			base.SetTextureByPath(value.ToggleLock, base.GetTexture(5), null, null);
			UUIItem item4 = base.GetItem(6);
			if (item4 == null)
			{
				return;
			}
			item4.SetUIActive(false);
		}

		// Token: 0x0603D198 RID: 250264 RVA: 0x00F84FF4 File Offset: 0x00F831F4
		protected void RefreshRemainTime()
		{
			string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey("BossPilingActivity_Main03");
			string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText((long)this.CurrentData.UnlockTime, configTextByKey);
			UUIText text = base.GetText(10);
			if (text == null)
			{
				return;
			}
			text.SetText(remainTimeText, true);
		}

		// Token: 0x0603D199 RID: 250265 RVA: 0x00F8503D File Offset: 0x00F8323D
		private void SetSelected(bool bSelectOn, bool bFireEvent = false)
		{
			base.GetExtendToggle(0).SetToggleState(bSelectOn ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, bFireEvent, false, false);
		}

		// Token: 0x0603D19A RID: 250266 RVA: 0x00F85056 File Offset: 0x00F83256
		private bool CheckIsUnlock()
		{
			if (this.CurrentData.IsUnlock)
			{
				return true;
			}
			bool flag = (double)this.CurrentData.UnlockTime <= Singleton<TimeUtil>.Instance.GetServerTime();
			if (flag)
			{
				this.CurrentData.IsUnlock = true;
			}
			return flag;
		}

		// Token: 0x0603D19B RID: 250267 RVA: 0x00F85091 File Offset: 0x00F83291
		private BossPilingBossAchievementStar CreateStar()
		{
			return new BossPilingBossAchievementStar();
		}

		// Token: 0x0603D19C RID: 250268 RVA: 0x00F85098 File Offset: 0x00F83298
		private void OnToggleStateChange(EToggleState state)
		{
			if (this.OnToggleStateChangeFunction != null)
			{
				UUIItem item = base.GetItem(6);
				if (item != null)
				{
					item.SetUIActive(false);
				}
				this.OnToggleStateChangeFunction(this.CurrentId);
			}
		}

		// Token: 0x0603D19D RID: 250269 RVA: 0x00F850C8 File Offset: 0x00F832C8
		private void OnUndeterminedClickToggle()
		{
			if (!this.CheckIsUnlock())
			{
				string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey("BossPilingActivity_Main03");
				string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText((long)this.CurrentData.UnlockTime, configTextByKey);
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(remainTimeText);
			}
		}

		// Token: 0x04022448 RID: 140360
		protected int CurrentId;

		// Token: 0x04022449 RID: 140361
		protected BossPilingLevelInfo CurrentData;

		// Token: 0x0402244A RID: 140362
		[Nullable(2)]
		public Func<int, bool> IsSelectOnCb;

		// Token: 0x0402244B RID: 140363
		[Nullable(2)]
		public Action<int> OnToggleStateChangeFunction;

		// Token: 0x0402244C RID: 140364
		protected GenericLayout<BossPilingBossAchievementStar, bool> Layout;

		// Token: 0x0200BF04 RID: 48900
		[NullableContext(0)]
		private enum EDefine
		{
			// Token: 0x0403ACA5 RID: 240805
			ToggleSelf,
			// Token: 0x0403ACA6 RID: 240806
			BossName,
			// Token: 0x0403ACA7 RID: 240807
			PanelStar,
			// Token: 0x0403ACA8 RID: 240808
			StarItem,
			// Token: 0x0403ACA9 RID: 240809
			SpriteScoreIcon,
			// Token: 0x0403ACAA RID: 240810
			TexBoss,
			// Token: 0x0403ACAB RID: 240811
			RedDot,
			// Token: 0x0403ACAC RID: 240812
			SpriteToggleBg,
			// Token: 0x0403ACAD RID: 240813
			PanelContent,
			// Token: 0x0403ACAE RID: 240814
			PanelBossNone,
			// Token: 0x0403ACAF RID: 240815
			TxtTime
		}
	}
}
