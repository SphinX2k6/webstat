using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A4D RID: 19021
	[NullableContext(1)]
	[Nullable(0)]
	public class UiMask
	{
		// Token: 0x06031B54 RID: 203604 RVA: 0x00C6396F File Offset: 0x00C61B6F
		private void RemoveMaskTimer(MaskData maskData)
		{
			if (maskData.Timer != null)
			{
				TimerSystem.Instance.Remove(maskData.Timer);
				maskData.Timer = null;
			}
		}

		// Token: 0x06031B55 RID: 203605 RVA: 0x00C63994 File Offset: 0x00C61B94
		[return: Nullable(2)]
		private TimerHandle CreateTimer(string maskTag, int count)
		{
			return TimerSystem.Instance.Delay(delegate(float arg)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiMask;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "[UiMask]超过保底时间,定时器执行逻辑,解除遮罩";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MaskTag", maskTag);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.ClearMaskData(maskTag);
			}, 2000f, null, null, true, 1f);
		}

		// Token: 0x06031B56 RID: 203606 RVA: 0x00C639D8 File Offset: 0x00C61BD8
		private void AddMaskTimer(MaskData maskData)
		{
			maskData.Timer = this.CreateTimer(maskData.Tag, maskData.Count);
			Singleton<UiLayer>.Instance.SetShowMaskLayer(maskData.Tag, true);
		}

		// Token: 0x06031B57 RID: 203607 RVA: 0x00C63A04 File Offset: 0x00C61C04
		private void AddMaskData(string maskTag)
		{
			MaskData maskData;
			if (this.MaskDataMap.TryGetValue(maskTag, out maskData))
			{
				this.RemoveMaskTimer(maskData);
				maskData.Count++;
				this.AddMaskTimer(maskData);
				return;
			}
			maskData = new MaskData
			{
				Tag = maskTag,
				Timer = null,
				Count = 1
			};
			this.MaskDataMap[maskTag] = maskData;
			this.AddMaskTimer(maskData);
		}

		// Token: 0x06031B58 RID: 203608 RVA: 0x00C63A70 File Offset: 0x00C61C70
		private void RemoveMaskData(string maskTag)
		{
			MaskData maskData;
			if (!this.MaskDataMap.TryGetValue(maskTag, out maskData))
			{
				return;
			}
			maskData.Count--;
			if (maskData.Count <= 0)
			{
				this.RemoveMaskTimer(maskData);
				this.ClearMaskData(maskTag);
			}
		}

		// Token: 0x06031B59 RID: 203609 RVA: 0x00C63AB3 File Offset: 0x00C61CB3
		private void ClearMaskData(string maskTag)
		{
			this.MaskDataMap.Remove(maskTag);
			Singleton<UiLayer>.Instance.SetShowMaskLayer(maskTag, false);
		}

		// Token: 0x06031B5A RID: 203610 RVA: 0x00C63ACE File Offset: 0x00C61CCE
		public void SetMask(string maskTag, bool value)
		{
			if (value)
			{
				this.AddMaskData(maskTag);
				return;
			}
			this.RemoveMaskData(maskTag);
		}

		// Token: 0x0401CEAB RID: 118443
		private const int MASK_DESTROY_TIME = 2000;

		// Token: 0x0401CEAC RID: 118444
		private readonly Dictionary<string, MaskData> MaskDataMap = new Dictionary<string, MaskData>();
	}
}
