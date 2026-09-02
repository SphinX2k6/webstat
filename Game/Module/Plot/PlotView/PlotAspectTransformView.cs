using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053B5 RID: 21429
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotAspectTransformView : UiPanelBase
	{
		// Token: 0x06036A64 RID: 223844 RVA: 0x00DD8220 File Offset: 0x00DD6420
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06036A65 RID: 223845 RVA: 0x00DD828C File Offset: 0x00DD648C
		protected override void OnStart()
		{
			this.Texture1 = base.GetTexture(0);
			UUITexture texture = this.Texture1;
			if (texture != null)
			{
				texture.SetUIActive(false);
			}
			UUITexture texture2 = this.Texture1;
			if (texture2 != null)
			{
				texture2.SetAlpha(1f);
			}
			this.Texture2 = base.GetTexture(1);
			UUITexture texture3 = this.Texture2;
			if (texture3 != null)
			{
				texture3.SetUIActive(false);
			}
			UUITexture texture4 = this.Texture2;
			if (texture4 != null)
			{
				texture4.SetAlpha(1f);
			}
			base.GetRootItem().GetRenderCanvas().bPostTickUpdate = true;
			base.GetRootItem().SetRaycastTarget(false);
			Singleton<EventSystem>.Instance.Add(EEventName.UIViewPortSizeChanged, new Action(this.OnSizeChanged));
		}

		// Token: 0x06036A66 RID: 223846 RVA: 0x00DD8339 File Offset: 0x00DD6539
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.UIViewPortSizeChanged, new Action(this.OnSizeChanged));
		}

		// Token: 0x06036A67 RID: 223847 RVA: 0x00DD8354 File Offset: 0x00DD6554
		protected override void OnBeforeShow()
		{
		}

		// Token: 0x06036A68 RID: 223848 RVA: 0x00DD8356 File Offset: 0x00DD6556
		protected override void OnAfterShow()
		{
		}

		// Token: 0x06036A69 RID: 223849 RVA: 0x00DD8358 File Offset: 0x00DD6558
		protected override void OnBeforeHide()
		{
			Singleton<TickSystem>.Instance.Remove(this.TickHandle);
			this.TickHandle = -1;
		}

		// Token: 0x06036A6A RID: 223850 RVA: 0x00DD8372 File Offset: 0x00DD6572
		public void EnableAutoBlendOut(float blendTime)
		{
			this.BlendTime = blendTime;
			this.BeforeRatio = this.RootItem.GetWidth() / this.RootItem.GetHeight();
			this.StartBySizeChanged = true;
		}

		// Token: 0x06036A6B RID: 223851 RVA: 0x00DD83A0 File Offset: 0x00DD65A0
		public void ManualBlendOut(float blendTime, float startRatio, Action callback = null, bool autoClose = true)
		{
			this.BlendTime = blendTime;
			this.Callback = callback;
			this.AutoClose = autoClose;
			this.BeforeRatio = startRatio;
			this.AfterRatio = this.RootItem.GetWidth() / this.RootItem.GetHeight();
			this.StartTransform();
		}

		// Token: 0x06036A6C RID: 223852 RVA: 0x00DD83F0 File Offset: 0x00DD65F0
		public void SetAspectRatio(float ratio)
		{
			UUITexture texture = this.Texture1;
			if (texture != null)
			{
				texture.SetUIActive(true);
			}
			UUITexture texture2 = this.Texture2;
			if (texture2 != null)
			{
				texture2.SetUIActive(true);
			}
			UUITexture texture3 = this.Texture1;
			if (texture3 != null)
			{
				texture3.SetStretchRight(0f);
			}
			UUITexture texture4 = this.Texture2;
			if (texture4 != null)
			{
				texture4.SetStretchRight(0f);
			}
			UUITexture texture5 = this.Texture1;
			if (texture5 != null)
			{
				texture5.SetStretchLeft(0f);
			}
			UUITexture texture6 = this.Texture2;
			if (texture6 != null)
			{
				texture6.SetStretchLeft(0f);
			}
			UUITexture texture7 = this.Texture1;
			if (texture7 != null)
			{
				texture7.SetStretchTop(0f);
			}
			UUITexture texture8 = this.Texture2;
			if (texture8 != null)
			{
				texture8.SetStretchTop(0f);
			}
			UUITexture texture9 = this.Texture1;
			if (texture9 != null)
			{
				texture9.SetStretchBottom(0f);
			}
			UUITexture texture10 = this.Texture2;
			if (texture10 != null)
			{
				texture10.SetStretchBottom(0f);
			}
			float width = this.RootItem.GetWidth();
			float height = this.RootItem.GetHeight();
			float num = width / height;
			if (ratio < num)
			{
				float num2 = height * ratio;
				float num3 = width / 2f + num2 / 2f;
				UUITexture texture11 = this.Texture1;
				if (texture11 != null)
				{
					texture11.SetStretchRight(num3);
				}
				UUITexture texture12 = this.Texture2;
				if (texture12 == null)
				{
					return;
				}
				texture12.SetStretchLeft(num3);
				return;
			}
			else
			{
				float num4 = width / ratio;
				float num5 = height / 2f + num4 / 2f;
				UUITexture texture13 = this.Texture1;
				if (texture13 != null)
				{
					texture13.SetStretchTop(num5);
				}
				UUITexture texture14 = this.Texture2;
				if (texture14 == null)
				{
					return;
				}
				texture14.SetStretchBottom(num5);
				return;
			}
		}

		// Token: 0x06036A6D RID: 223853 RVA: 0x00DD8568 File Offset: 0x00DD6768
		private void OnTick(float delta)
		{
			if (this.Duration > this.BlendTime)
			{
				if (this.AutoClose)
				{
					ControllerBase<PlotController>.Instance.RemoveAspectTransformView();
				}
				else
				{
					base.Hide(null);
				}
				Action callback = this.Callback;
				if (callback == null)
				{
					return;
				}
				callback();
				return;
			}
			else
			{
				this.Duration += delta;
				this.CurrentValue += delta * this.Speed;
				if (this.IsWidthBlend)
				{
					UUITexture texture = this.Texture1;
					if (texture != null)
					{
						texture.SetStretchRight(this.CurrentValue);
					}
					UUITexture texture2 = this.Texture2;
					if (texture2 == null)
					{
						return;
					}
					texture2.SetStretchLeft(this.CurrentValue);
					return;
				}
				else
				{
					UUITexture texture3 = this.Texture1;
					if (texture3 != null)
					{
						texture3.SetStretchTop(this.CurrentValue);
					}
					UUITexture texture4 = this.Texture2;
					if (texture4 == null)
					{
						return;
					}
					texture4.SetStretchBottom(this.CurrentValue);
					return;
				}
			}
		}

		// Token: 0x06036A6E RID: 223854 RVA: 0x00DD8638 File Offset: 0x00DD6838
		private void OnSizeChanged()
		{
			if (!this.StartBySizeChanged)
			{
				return;
			}
			float width = this.RootItem.GetWidth();
			float height = this.RootItem.GetHeight();
			this.AfterRatio = width / height;
			this.StartBySizeChanged = false;
			this.StartTransform();
		}

		// Token: 0x06036A6F RID: 223855 RVA: 0x00DD867C File Offset: 0x00DD687C
		private void StartTransform()
		{
			UUITexture texture = this.Texture1;
			if (texture != null)
			{
				texture.SetUIActive(true);
			}
			UUITexture texture2 = this.Texture2;
			if (texture2 != null)
			{
				texture2.SetUIActive(true);
			}
			UUITexture texture3 = this.Texture1;
			if (texture3 != null)
			{
				texture3.SetStretchRight(0f);
			}
			UUITexture texture4 = this.Texture2;
			if (texture4 != null)
			{
				texture4.SetStretchRight(0f);
			}
			UUITexture texture5 = this.Texture1;
			if (texture5 != null)
			{
				texture5.SetStretchLeft(0f);
			}
			UUITexture texture6 = this.Texture2;
			if (texture6 != null)
			{
				texture6.SetStretchLeft(0f);
			}
			UUITexture texture7 = this.Texture1;
			if (texture7 != null)
			{
				texture7.SetStretchTop(0f);
			}
			UUITexture texture8 = this.Texture2;
			if (texture8 != null)
			{
				texture8.SetStretchTop(0f);
			}
			UUITexture texture9 = this.Texture1;
			if (texture9 != null)
			{
				texture9.SetStretchBottom(0f);
			}
			UUITexture texture10 = this.Texture2;
			if (texture10 != null)
			{
				texture10.SetStretchBottom(0f);
			}
			float width = this.RootItem.GetWidth();
			float height = this.RootItem.GetHeight();
			if (this.BeforeRatio < this.AfterRatio)
			{
				this.IsWidthBlend = true;
				float num = height * this.BeforeRatio;
				float num2 = width / 2f + num / 2f;
				UUITexture texture11 = this.Texture1;
				if (texture11 != null)
				{
					texture11.SetStretchRight(num2);
				}
				UUITexture texture12 = this.Texture2;
				if (texture12 != null)
				{
					texture12.SetStretchLeft(num2);
				}
				this.Speed = (width - num) / 2f / this.BlendTime;
				this.CurrentValue = num2;
			}
			else
			{
				this.IsWidthBlend = false;
				float num3 = width / this.BeforeRatio;
				float num4 = height / 2f + num3 / 2f;
				UUITexture texture13 = this.Texture1;
				if (texture13 != null)
				{
					texture13.SetStretchTop(num4);
				}
				UUITexture texture14 = this.Texture2;
				if (texture14 != null)
				{
					texture14.SetStretchBottom(num4);
				}
				this.Speed = (height - num3) / 2f / this.BlendTime;
				this.CurrentValue = num4;
			}
			this.TickHandle = Singleton<TickSystem>.Instance.Add(new Action<float>(this.OnTick), "PlotAspectTransformView", ETickingGroup.TG_PrePhysics, false, 0, false).Id;
		}

		// Token: 0x0401F7AA RID: 128938
		private bool StartBySizeChanged;

		// Token: 0x0401F7AB RID: 128939
		private UUITexture Texture1;

		// Token: 0x0401F7AC RID: 128940
		private UUITexture Texture2;

		// Token: 0x0401F7AD RID: 128941
		private float BeforeRatio;

		// Token: 0x0401F7AE RID: 128942
		private float AfterRatio;

		// Token: 0x0401F7AF RID: 128943
		private float BlendTime;

		// Token: 0x0401F7B0 RID: 128944
		private float Duration;

		// Token: 0x0401F7B1 RID: 128945
		private float Speed;

		// Token: 0x0401F7B2 RID: 128946
		private float CurrentValue;

		// Token: 0x0401F7B3 RID: 128947
		private bool IsWidthBlend;

		// Token: 0x0401F7B4 RID: 128948
		private int TickHandle = -1;

		// Token: 0x0401F7B5 RID: 128949
		private bool AutoClose;

		// Token: 0x0401F7B6 RID: 128950
		private Action Callback;

		// Token: 0x0200B31E RID: 45854
		[NullableContext(0)]
		private static class EChildItem
		{
			// Token: 0x040377D7 RID: 227287
			public const int Texture1 = 0;

			// Token: 0x040377D8 RID: 227288
			public const int Texture2 = 1;
		}
	}
}
