using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Functional
{
	// Token: 0x02005D1D RID: 23837
	public class FunctionResDownLoadItem : UiPanelBase
	{
		// Token: 0x0603C1B8 RID: 246200 RVA: 0x00F3E038 File Offset: 0x00F3C238
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnDownLoadBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603C1B9 RID: 246201 RVA: 0x00F3E0DE File Offset: 0x00F3C2DE
		protected override void OnStart()
		{
			this.AddEventListeners();
		}

		// Token: 0x0603C1BA RID: 246202 RVA: 0x00F3E0E6 File Offset: 0x00F3C2E6
		protected override void OnBeforeDestroy()
		{
			this.RemoveEventListeners();
			if (this.TimerHandle != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
		}

		// Token: 0x0603C1BB RID: 246203 RVA: 0x00F3E10E File Offset: 0x00F3C30E
		private void AddEventListeners()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshSubPackDownLoadState, new Action(this.ResDownLoadStateRefresh));
		}

		// Token: 0x0603C1BC RID: 246204 RVA: 0x00F3E12C File Offset: 0x00F3C32C
		private void RemoveEventListeners()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshSubPackDownLoadState, new Action(this.ResDownLoadStateRefresh));
		}

		// Token: 0x0603C1BD RID: 246205 RVA: 0x00F3E14A File Offset: 0x00F3C34A
		private void OnDownLoadBtnClick()
		{
			if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.SubPackageDownLoadView))
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.SubPackageDownLoadView, null, null);
			}
		}

		// Token: 0x0603C1BE RID: 246206 RVA: 0x00F3E16E File Offset: 0x00F3C36E
		private void ResDownLoadStateRefresh()
		{
			this.Update();
		}

		// Token: 0x0603C1BF RID: 246207 RVA: 0x00F3E176 File Offset: 0x00F3C376
		public void Update()
		{
			this.Refresh();
		}

		// Token: 0x0603C1C0 RID: 246208 RVA: 0x00F3E180 File Offset: 0x00F3C380
		public void Refresh()
		{
			UUITexture texture = base.GetTexture(0);
			ValueTuple<float, ESubPackageDownLoadState> valueTuple = ModelBase<SubPackageDownLoadModel>.Instance.DownLoadPercentage();
			texture.SetFillAmount(valueTuple.Item1);
			FColor? fcolor;
			if (valueTuple.Item2 == ESubPackageDownLoadState.DownLoading)
			{
				UUIItem texture2 = base.GetTexture(0);
				bool bUseChangeColor = false;
				fcolor = new FColor?(texture.changeColor);
				texture2.SetChangeColor(bUseChangeColor, fcolor);
				return;
			}
			UUIItem texture3 = base.GetTexture(0);
			bool bUseChangeColor2 = true;
			fcolor = new FColor?(texture.changeColor);
			texture3.SetChangeColor(bUseChangeColor2, fcolor);
		}

		// Token: 0x0603C1C1 RID: 246209 RVA: 0x00F3E1EC File Offset: 0x00F3C3EC
		public void StartShow()
		{
			this.Update();
			if (this.TimerHandle != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
			this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float delta)
			{
				this.Update();
			}, (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
		}

		// Token: 0x0603C1C2 RID: 246210 RVA: 0x00F3E24E File Offset: 0x00F3C44E
		public void EndShow()
		{
			if (this.TimerHandle != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
		}

		// Token: 0x04021BEB RID: 138219
		[Nullable(2)]
		private TimerHandle TimerHandle;

		// Token: 0x0200BD8E RID: 48526
		private class EComponentDefine
		{
			// Token: 0x0403A613 RID: 239123
			public const int DownLoadBarTexture = 0;

			// Token: 0x0403A614 RID: 239124
			public const int DownLoadBtn = 1;
		}
	}
}
