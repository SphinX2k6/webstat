using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FD6 RID: 24534
	[NullableContext(2)]
	[Nullable(0)]
	public class BattleSkillSecondCdItem : UiPanelBase
	{
		// Token: 0x0603DBBE RID: 252862 RVA: 0x00FB9F96 File Offset: 0x00FB8196
		public void SetIndex(int index)
		{
			this.Index = index;
		}

		// Token: 0x0603DBBF RID: 252863 RVA: 0x00FB9FA0 File Offset: 0x00FB81A0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DBC0 RID: 252864 RVA: 0x00FB9FE8 File Offset: 0x00FB81E8
		protected override void OnStart()
		{
			this.CoolDownBarUiSprite = base.GetSprite(0);
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			FRotator frotator = new FRotator(0f, (float)(this.Index * 90), 0f);
			rootItem.SetUIRelativeRotation(frotator);
		}

		// Token: 0x0603DBC1 RID: 252865 RVA: 0x00FBA030 File Offset: 0x00FB8230
		public void RefreshSkillCoolDown(SkillButtonData skillButtonData)
		{
			this.SkillButtonData = skillButtonData;
			if (this.SkillButtonData == null)
			{
				this.FinishSkillCoolDown();
				return;
			}
			if (this.IsSkillInItemUseBuffCd() && this.TryRefreshItemUseBuffCd())
			{
				return;
			}
			if (this.IsSkillInItemUseSkillCd() && this.TryRefreshItemUseSkillCd())
			{
				return;
			}
			if (this.SkillButtonData.IsMultiStageSkill().GetValueOrDefault() && this.TryRefreshMultiSkillCoolDown())
			{
				return;
			}
			this.TryRefreshCommonSkillCoolDown();
		}

		// Token: 0x0603DBC2 RID: 252866 RVA: 0x00FBA099 File Offset: 0x00FB8299
		public void Tick(float delta)
		{
			this.TickSkillCoolDown(delta);
		}

		// Token: 0x0603DBC3 RID: 252867 RVA: 0x00FBA0A2 File Offset: 0x00FB82A2
		private void PlayCommonCd(float remainingCoolDown, float totalCoolDown)
		{
			this.CurrentCoolDownTime = 0f;
			if (remainingCoolDown <= 0f)
			{
				this.FinishSkillCoolDown();
				return;
			}
			this.CurrentCoolDownTime = remainingCoolDown;
			this.TotalCoolDownTime = totalCoolDown;
			if (!base.IsShowOrShowing)
			{
				base.Show(null);
			}
		}

		// Token: 0x0603DBC4 RID: 252868 RVA: 0x00FBA0DB File Offset: 0x00FB82DB
		private void FinishSkillCoolDown()
		{
			if (base.IsShowOrShowing)
			{
				base.Hide(null);
			}
			this.CurrentCoolDownTime = 0f;
		}

		// Token: 0x0603DBC5 RID: 252869 RVA: 0x00FBA0F8 File Offset: 0x00FB82F8
		private void TickSkillCoolDown(float delta)
		{
			if (this.CurrentCoolDownTime <= 0f || this.TotalCoolDownTime <= 0f || this.CoolDownBarUiSprite == null)
			{
				return;
			}
			if (ControllerBase<SkillCdController>.Instance.IsPause() || Singleton<Time>.Instance.TimeDilation <= 0f)
			{
				return;
			}
			this.CurrentCoolDownTime -= delta * Singleton<Time>.Instance.TimeDilation * (float)Singleton<TimeUtil>.Instance.Millisecond;
			if (this.CurrentCoolDownTime < 0f)
			{
				this.CurrentCoolDownTime = 0f;
				this.CoolDownBarUiSprite.SetFillAmount(0f);
				this.FinishSkillCoolDown();
				return;
			}
			float num = this.CurrentCoolDownTime / this.TotalCoolDownTime;
			num = 0.3f + num * 0.4f;
			this.CoolDownBarUiSprite.SetFillAmount(num);
		}

		// Token: 0x0603DBC6 RID: 252870 RVA: 0x00FBA1C2 File Offset: 0x00FB83C2
		private bool IsSkillInItemUseBuffCd()
		{
			SkillButtonData skillButtonData = this.SkillButtonData;
			return skillButtonData != null && skillButtonData.GetButtonType() == ESkillButtonType.幻象1 && this.SkillButtonData.IsSkillInItemUseBuffCd();
		}

		// Token: 0x0603DBC7 RID: 252871 RVA: 0x00FBA1EC File Offset: 0x00FB83EC
		private bool TryRefreshItemUseBuffCd()
		{
			ValueTuple<double, double> equippedItemUsingBuffCd = this.SkillButtonData.GetEquippedItemUsingBuffCd();
			double item = equippedItemUsingBuffCd.Item1;
			double item2 = equippedItemUsingBuffCd.Item2;
			if (item > 0.0)
			{
				this.PlayCommonCd((float)item, (float)item2);
				return true;
			}
			return false;
		}

		// Token: 0x0603DBC8 RID: 252872 RVA: 0x00FBA22A File Offset: 0x00FB842A
		private bool IsSkillInItemUseSkillCd()
		{
			SkillButtonData skillButtonData = this.SkillButtonData;
			return skillButtonData != null && skillButtonData.GetButtonType() == ESkillButtonType.幻象1 && this.SkillButtonData.IsSkillInItemUseSkillCd();
		}

		// Token: 0x0603DBC9 RID: 252873 RVA: 0x00FBA254 File Offset: 0x00FB8454
		private bool TryRefreshItemUseSkillCd()
		{
			ValueTuple<double, double> equippedItemUsingSkillCd = this.SkillButtonData.GetEquippedItemUsingSkillCd();
			double item = equippedItemUsingSkillCd.Item1;
			double item2 = equippedItemUsingSkillCd.Item2;
			if (item > 0.0)
			{
				this.PlayCommonCd((float)item, (float)item2);
				return true;
			}
			return false;
		}

		// Token: 0x0603DBCA RID: 252874 RVA: 0x00FBA294 File Offset: 0x00FB8494
		private bool TryRefreshMultiSkillCoolDown()
		{
			MultiSkillInfo multiSkillInfo = this.SkillButtonData.GetMultiSkillInfo();
			if (multiSkillInfo != null)
			{
				int? nextSkillId = multiSkillInfo.NextSkillId;
				int num = 0;
				if (!(nextSkillId.GetValueOrDefault() == num & nextSkillId != null))
				{
					double remainingStartTime = multiSkillInfo.RemainingStartTime;
					float startTime = multiSkillInfo.StartTime;
					if (remainingStartTime > 0.0)
					{
						this.PlayCommonCd((float)remainingStartTime, startTime);
					}
					else
					{
						this.FinishSkillCoolDown();
					}
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603DBCB RID: 252875 RVA: 0x00FBA300 File Offset: 0x00FB8500
		private void TryRefreshCommonSkillCoolDown()
		{
			GroupSkillCdInfo groupSkillCdInfo = this.SkillButtonData.GetGroupSkillCdInfo();
			if (groupSkillCdInfo == null)
			{
				return;
			}
			float curRemainingCd = groupSkillCdInfo.CurRemainingCd;
			float curMaxCd = groupSkillCdInfo.CurMaxCd;
			this.PlayCommonCd(curRemainingCd, curMaxCd);
		}

		// Token: 0x04022A28 RID: 141864
		private const float AMOUNT_START = 0.3f;

		// Token: 0x04022A29 RID: 141865
		private const float AMOUNT_SCALE = 0.4f;

		// Token: 0x04022A2A RID: 141866
		private int Index;

		// Token: 0x04022A2B RID: 141867
		private SkillButtonData SkillButtonData;

		// Token: 0x04022A2C RID: 141868
		private UUISprite CoolDownBarUiSprite;

		// Token: 0x04022A2D RID: 141869
		private float CurrentCoolDownTime;

		// Token: 0x04022A2E RID: 141870
		private float TotalCoolDownTime;

		// Token: 0x0200C047 RID: 49223
		[NullableContext(0)]
		private enum EBattleSkillItem
		{
			// Token: 0x0403B2F7 RID: 242423
			CoolDownBarSprite
		}
	}
}
