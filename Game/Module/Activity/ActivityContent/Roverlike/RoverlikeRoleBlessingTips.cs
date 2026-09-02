using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006413 RID: 25619
	public class RoverlikeRoleBlessingTips : UiViewBase
	{
		// Token: 0x0604051C RID: 263452 RVA: 0x0107CD59 File Offset: 0x0107AF59
		[NullableContext(1)]
		public RoverlikeRoleBlessingTips(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0604051D RID: 263453 RVA: 0x0107CD64 File Offset: 0x0107AF64
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0604051E RID: 263454 RVA: 0x0107CE10 File Offset: 0x0107B010
		protected override void OnBeforeShow()
		{
			RoverlikeGainEntry roverlikeGainEntry = this.OpenParam as RoverlikeGainEntry;
			if (roverlikeGainEntry == null)
			{
				return;
			}
			this.RefreshTips(roverlikeGainEntry);
		}

		// Token: 0x0604051F RID: 263455 RVA: 0x0107CE34 File Offset: 0x0107B034
		protected override void OnFinishShow()
		{
			RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
			int? num;
			if (instance == null)
			{
				num = null;
			}
			else
			{
				RoverlikeActivityData currentActivityData = instance.GetCurrentActivityData();
				num = ((currentActivityData != null) ? new int?(currentActivityData.GetParamConfig().Value.BlessRoleInfoShowTime) : null);
			}
			int? num2 = num;
			int valueOrDefault = num2.GetValueOrDefault();
			if (valueOrDefault <= 0)
			{
				base.CloseMe(null);
				return;
			}
			this.ClearCloseTimer();
			this.CloseTimer = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.CloseTimer = null;
				base.CloseMe(null);
			}, (float)valueOrDefault, null, null, true, 1f);
		}

		// Token: 0x06040520 RID: 263456 RVA: 0x0107CEC4 File Offset: 0x0107B0C4
		protected override void OnBeforeDestroy()
		{
			this.ClearCloseTimer();
		}

		// Token: 0x06040521 RID: 263457 RVA: 0x0107CECC File Offset: 0x0107B0CC
		[NullableContext(1)]
		private void RefreshTips(RoverlikeGainEntry entry)
		{
			RoverRogueBless? blessConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessConfig(entry.ConfigId);
			if (blessConfig == null)
			{
				return;
			}
			RoverRogueBlessRole? blessRoleConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessRoleConfig(blessConfig.Value.BlessRoleId);
			if (blessRoleConfig != null)
			{
				base.SetTextureShowUntilLoaded(blessRoleConfig.Value.RoleIcon, base.GetTexture(1), null);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), blessRoleConfig.Value.BlessRoleName, Array.Empty<object>());
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), blessConfig.Value.TriggerRoleInfo, Array.Empty<object>());
		}

		// Token: 0x06040522 RID: 263458 RVA: 0x0107CF7E File Offset: 0x0107B17E
		private void ClearCloseTimer()
		{
			if (this.CloseTimer != null && TimerSystem.Instance.Has(this.CloseTimer))
			{
				TimerSystem.Instance.Remove(this.CloseTimer);
			}
			this.CloseTimer = null;
		}

		// Token: 0x040240C2 RID: 147650
		[Nullable(2)]
		private TimerHandle CloseTimer;

		// Token: 0x0200C481 RID: 50305
		private class EComponents
		{
			// Token: 0x0403C7C8 RID: 247752
			public const int PanelSelf = 0;

			// Token: 0x0403C7C9 RID: 247753
			public const int TexHeadIcon = 1;

			// Token: 0x0403C7CA RID: 247754
			public const int TxtName = 2;

			// Token: 0x0403C7CB RID: 247755
			public const int TxtInfo = 3;
		}
	}
}
