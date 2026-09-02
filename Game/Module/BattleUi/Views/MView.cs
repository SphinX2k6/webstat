using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.BaseConfig;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200608B RID: 24715
	public class MView : UiTickViewBase
	{
		// Token: 0x0603E5AE RID: 255406 RVA: 0x00FECB0B File Offset: 0x00FEAD0B
		[NullableContext(1)]
		public MView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603E5AF RID: 255407 RVA: 0x00FECB20 File Offset: 0x00FEAD20
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E5B0 RID: 255408 RVA: 0x00FECB68 File Offset: 0x00FEAD68
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.MReady, new Action(this.UpdateMask));
		}

		// Token: 0x0603E5B1 RID: 255409 RVA: 0x00FECB86 File Offset: 0x00FEAD86
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.MReady, new Action(this.UpdateMask));
		}

		// Token: 0x0603E5B2 RID: 255410 RVA: 0x00FECBA4 File Offset: 0x00FEADA4
		protected override void OnStart()
		{
			if (!Singleton<BaseConfigController>.Instance.GetRptIsOpen())
			{
				this.MaskReady = true;
				return;
			}
			this.MaskPath = ModelBase<LoginModel>.Instance.GetWaterMarkPath();
			this.InitMask();
		}

		// Token: 0x0603E5B3 RID: 255411 RVA: 0x00FECBD0 File Offset: 0x00FEADD0
		protected override void OnTick(float deltaTime)
		{
			if (this.MaskReady)
			{
				return;
			}
			if (this.MaskCheckTimeMs > 1000)
			{
				this.MaskCheckTimeMs = 0;
				this.InitMask();
				return;
			}
			this.MaskCheckTimeMs += (int)deltaTime;
		}

		// Token: 0x0603E5B4 RID: 255412 RVA: 0x00FECC05 File Offset: 0x00FEAE05
		private void UpdateMask()
		{
			this.InitMask();
		}

		// Token: 0x0603E5B5 RID: 255413 RVA: 0x00FECC10 File Offset: 0x00FEAE10
		private void InitMask()
		{
			if (UKuroStaticLibrary.FileExists(this.MaskPath))
			{
				this.MaskReady = true;
				UUITexture texture = base.GetTexture(0);
				string maskPath = this.MaskPath;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Mask");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.Index);
				UTexture2D utexture2D = ULGUIBPLibrary.CreateTexture2DFromPath(maskPath, defaultInterpolatedStringHandler.ToStringAndClear(), 0);
				this.Index++;
				if (utexture2D != null)
				{
					if (texture != null)
					{
						texture.SetTexture(utexture2D);
					}
					if (texture != null)
					{
						texture.SetUIActive(true);
					}
				}
			}
		}

		// Token: 0x04022F28 RID: 143144
		private const int CHECK_INTERVAL = 1000;

		// Token: 0x04022F29 RID: 143145
		private bool MaskReady;

		// Token: 0x04022F2A RID: 143146
		[Nullable(1)]
		private string MaskPath = "";

		// Token: 0x04022F2B RID: 143147
		private int MaskCheckTimeMs;

		// Token: 0x04022F2C RID: 143148
		private int Index;

		// Token: 0x0200C177 RID: 49527
		private enum EComponents
		{
			// Token: 0x0403B937 RID: 244023
			ItemMask
		}
	}
}
