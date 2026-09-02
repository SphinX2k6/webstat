using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour
{
	// Token: 0x020066B7 RID: 26295
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MotorParkourLevelItem : GridProxyAbstract<MotorParkourLevelData>
	{
		// Token: 0x06041A90 RID: 268944 RVA: 0x010D6224 File Offset: 0x010D4424
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIExtendToggleTextureTransition));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041A91 RID: 268945 RVA: 0x010D636F File Offset: 0x010D456F
		protected override void OnStart()
		{
			base.GetExtendToggle(0).bLockStateOnSelect = true;
		}

		// Token: 0x06041A92 RID: 268946 RVA: 0x010D6380 File Offset: 0x010D4580
		public override UniTask RefreshAsync(MotorParkourLevelData data, bool isSelected, int gridIndex)
		{
			MotorParkourLevelItem.<RefreshAsync>d__6 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.data = data;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<MotorParkourLevelItem.<RefreshAsync>d__6>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041A93 RID: 268947 RVA: 0x010D63CB File Offset: 0x010D45CB
		private void UpdateUnlock()
		{
			if (this.Data != null && this.Data.IsUnLock)
			{
				this.RefreshAsync(this.Data, false, 0);
			}
		}

		// Token: 0x06041A94 RID: 268948 RVA: 0x010D63F1 File Offset: 0x010D45F1
		private void AddTimer()
		{
			this.RemoveTimer();
			this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
			{
				this.UpdateUnlock();
			}, (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
		}

		// Token: 0x06041A95 RID: 268949 RVA: 0x010D6428 File Offset: 0x010D4628
		private void RemoveTimer()
		{
			if (this.TimerHandle != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
		}

		// Token: 0x06041A96 RID: 268950 RVA: 0x010D644C File Offset: 0x010D464C
		public override void OnSelected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
			}
			if (this.Data.HasLevelRedDot)
			{
				this.Data.ReadLevelRedDot();
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.Data.ActivityId);
			}
			UUIItem item = base.GetItem(6);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(this.Data.HasLevelRedDot);
		}

		// Token: 0x06041A97 RID: 268951 RVA: 0x010D64BF File Offset: 0x010D46BF
		public override void OnDeselected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x06041A98 RID: 268952 RVA: 0x010D64D7 File Offset: 0x010D46D7
		private void OnToggleClick(EToggleState _)
		{
			if (!this.Data.IsUnLock)
			{
				this.OnDeselected(false);
			}
			Action<MotorParkourLevelData> onToggleCallback = this.OnToggleCallback;
			if (onToggleCallback == null)
			{
				return;
			}
			onToggleCallback(this.Data);
		}

		// Token: 0x06041A99 RID: 268953 RVA: 0x010D6503 File Offset: 0x010D4703
		public override object GetKey(MotorParkourLevelData data, int displayIndex)
		{
			return data.Id;
		}

		// Token: 0x04024A71 RID: 150129
		private MotorParkourLevelData Data;

		// Token: 0x04024A72 RID: 150130
		[Nullable(2)]
		private TimerHandle TimerHandle;

		// Token: 0x04024A73 RID: 150131
		public Action<MotorParkourLevelData> OnToggleCallback = delegate(MotorParkourLevelData data)
		{
		};

		// Token: 0x0200C6DB RID: 50907
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D399 RID: 250777
			public const int ToggleRoot = 0;

			// Token: 0x0403D39A RID: 250778
			public const int TextureMap = 1;

			// Token: 0x0403D39B RID: 250779
			public const int ArtTextNum = 2;

			// Token: 0x0403D39C RID: 250780
			public const int ItemFinish = 3;

			// Token: 0x0403D39D RID: 250781
			public const int ItemLock = 4;

			// Token: 0x0403D39E RID: 250782
			public const int TextureTransitionMap = 5;

			// Token: 0x0403D39F RID: 250783
			public const int ItemRedDot = 6;
		}
	}
}
