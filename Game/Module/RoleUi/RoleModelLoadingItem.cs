using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi
{
	// Token: 0x02005054 RID: 20564
	public class RoleModelLoadingItem : UiPanelBase
	{
		// Token: 0x06034F19 RID: 216857 RVA: 0x00D46C98 File Offset: 0x00D44E98
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06034F1A RID: 216858 RVA: 0x00D46CE0 File Offset: 0x00D44EE0
		protected override void OnStart()
		{
			this.RefreshLoadingActive();
		}

		// Token: 0x06034F1B RID: 216859 RVA: 0x00D46CE8 File Offset: 0x00D44EE8
		protected override void OnBeforeDestroy()
		{
			this.ClearTimerHandle();
		}

		// Token: 0x06034F1C RID: 216860 RVA: 0x00D46CF0 File Offset: 0x00D44EF0
		private void ClearTimerHandle()
		{
			if (this.TimerHandle != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
		}

		// Token: 0x06034F1D RID: 216861 RVA: 0x00D46D12 File Offset: 0x00D44F12
		private void RefreshLoadingActive()
		{
			this.SetActive(this.CacheActiveState && this.IsOpen);
		}

		// Token: 0x06034F1E RID: 216862 RVA: 0x00D46D2B File Offset: 0x00D44F2B
		public void SetLoadingOpen(bool value)
		{
			this.IsOpen = value;
		}

		// Token: 0x06034F1F RID: 216863 RVA: 0x00D46D34 File Offset: 0x00D44F34
		public void SetLoadingActive(bool value)
		{
			if (this.CacheActiveState == value)
			{
				return;
			}
			this.CacheActiveState = value;
			if (value)
			{
				this.TimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
				{
					this.ClearTimerHandle();
					this.RefreshLoadingActive();
				}, 300f, null, null, true, 1f);
				return;
			}
			this.ClearTimerHandle();
			this.RefreshLoadingActive();
		}

		// Token: 0x06034F20 RID: 216864 RVA: 0x00D46D8B File Offset: 0x00D44F8B
		public void SetIconPosition(FVector2D position)
		{
			UUIItem item = base.GetItem(0);
			if (item == null)
			{
				return;
			}
			item.SetAnchorOffset(position);
		}

		// Token: 0x0401E83D RID: 124989
		private bool CacheActiveState = true;

		// Token: 0x0401E83E RID: 124990
		[Nullable(2)]
		private TimerHandle TimerHandle;

		// Token: 0x0401E83F RID: 124991
		private bool IsOpen = true;

		// Token: 0x0200AFF4 RID: 45044
		private class EComponent
		{
			// Token: 0x04036956 RID: 223574
			public const int IconItem = 0;
		}
	}
}
