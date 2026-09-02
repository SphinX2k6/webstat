using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor
{
	// Token: 0x02006651 RID: 26193
	public class MultiMotorChoseLevelItem : GridProxyAbstract<int>
	{
		// Token: 0x0604168B RID: 267915 RVA: 0x010C8514 File Offset: 0x010C6714
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggleTextureTransition));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604168C RID: 267916 RVA: 0x010C8660 File Offset: 0x010C6860
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.LevelId = data;
			OnlineMotorLevel? motorMultiParkourLevelById = ConfigBase<MultiMotorConfig>.Instance.GetMotorMultiParkourLevelById(this.LevelId);
			if (motorMultiParkourLevelById == null)
			{
				return;
			}
			UUIExtendToggleTextureTransition uiExtendToggleTextureTransition = base.GetUiExtendToggleTextureTransition(1);
			uiExtendToggleTextureTransition.RootUIComp.Get().SetUIActive(false);
			this.LoadTitleTextureAsync(motorMultiParkourLevelById.Value, uiExtendToggleTextureTransition).Forget();
			this.SetSpriteByPath(motorMultiParkourLevelById.Value.LevelTitleSprite, base.GetSprite(2), false, null, null);
			bool levelUnLock = ModelBase<MultiMotorModel>.Instance.GetLevelUnLock(this.LevelId);
			base.GetItem(4).SetUIActive(!levelUnLock);
			if (!levelUnLock)
			{
				base.GetItem(3).SetUIActive(false);
				base.GetSprite(6).SetUIActive(false);
				base.GetItem(5).SetUIActive(false);
				return;
			}
			MultiMotorLevelData multiMotorLevelData = null;
			MultiMotorData activityData = ModelBase<MultiMotorModel>.Instance.ActivityData;
			if (activityData != null)
			{
				activityData.LevelDataMap.TryGetValue(this.LevelId, out multiMotorLevelData);
			}
			bool uiactive = multiMotorLevelData != null && multiMotorLevelData.IsFinish;
			base.GetItem(3).SetUIActive(uiactive);
			base.GetItem(5).SetUIActive(multiMotorLevelData != null && multiMotorLevelData.HasLevelRedDot);
			int num = (multiMotorLevelData != null) ? multiMotorLevelData.BestRanking : 0;
			if (num > 0)
			{
				string resourceId;
				MultiMotorDefine.MultiMotorRankSprite.TryGetValue(num, out resourceId);
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
				this.SetSpriteByPath(resourcePath, base.GetSprite(6), false, null, null);
			}
			base.GetSprite(6).SetUIActive(num > 0);
		}

		// Token: 0x0604168D RID: 267917 RVA: 0x010C87EC File Offset: 0x010C69EC
		[NullableContext(1)]
		private UniTask LoadTitleTextureAsync(OnlineMotorLevel config, UUIExtendToggleTextureTransition titleTexture)
		{
			MultiMotorChoseLevelItem.<LoadTitleTextureAsync>d__5 <LoadTitleTextureAsync>d__;
			<LoadTitleTextureAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadTitleTextureAsync>d__.<>4__this = this;
			<LoadTitleTextureAsync>d__.config = config;
			<LoadTitleTextureAsync>d__.titleTexture = titleTexture;
			<LoadTitleTextureAsync>d__.<>1__state = -1;
			<LoadTitleTextureAsync>d__.<>t__builder.Start<MultiMotorChoseLevelItem.<LoadTitleTextureAsync>d__5>(ref <LoadTitleTextureAsync>d__);
			return <LoadTitleTextureAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604168E RID: 267918 RVA: 0x010C8840 File Offset: 0x010C6A40
		private void OnClickToggle(EToggleState _)
		{
			MultiMotorLevelData multiMotorLevelData = null;
			MultiMotorData activityData = ModelBase<MultiMotorModel>.Instance.ActivityData;
			if (activityData != null)
			{
				activityData.LevelDataMap.TryGetValue(this.LevelId, out multiMotorLevelData);
			}
			if (multiMotorLevelData != null && multiMotorLevelData.HasLevelRedDot)
			{
				multiMotorLevelData.ReadLevelRedDot();
				base.GetItem(5).SetUIActive(false);
			}
			Action<int, UUIExtendToggle> onClickToggleCallBack = this.OnClickToggleCallBack;
			if (onClickToggleCallBack == null)
			{
				return;
			}
			onClickToggleCallBack(this.LevelId, base.GetExtendToggle(0));
		}

		// Token: 0x0604168F RID: 267919 RVA: 0x010C88AD File Offset: 0x010C6AAD
		public void SelectToggle()
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, true, false, false);
		}

		// Token: 0x04024930 RID: 149808
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<int, UUIExtendToggle> OnClickToggleCallBack;

		// Token: 0x04024931 RID: 149809
		private int LevelId;

		// Token: 0x0200C673 RID: 50803
		private class EItemComponents
		{
			// Token: 0x0403D19E RID: 250270
			public const int Toggle = 0;

			// Token: 0x0403D19F RID: 250271
			public const int TitleTexture = 1;

			// Token: 0x0403D1A0 RID: 250272
			public const int NumberSprite = 2;

			// Token: 0x0403D1A1 RID: 250273
			public const int FinishItem = 3;

			// Token: 0x0403D1A2 RID: 250274
			public const int LockItem = 4;

			// Token: 0x0403D1A3 RID: 250275
			public const int RedDotItem = 5;

			// Token: 0x0403D1A4 RID: 250276
			public const int RankSprite = 6;
		}
	}
}
