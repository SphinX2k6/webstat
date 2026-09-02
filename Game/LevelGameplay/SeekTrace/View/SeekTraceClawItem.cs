using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.SeekTrace.View
{
	// Token: 0x02006B0D RID: 27405
	public class SeekTraceClawItem : UiPanelBase
	{
		// Token: 0x06043B6E RID: 277358 RVA: 0x011785E8 File Offset: 0x011767E8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06043B6F RID: 277359 RVA: 0x01178694 File Offset: 0x01176894
		protected override void OnBeforeShow()
		{
			string resourceId = "TraceClawType3Icon";
			string resourceId2 = "TraceClawType3Bg";
			ETraceTracingImageType iconType = ModelBase<SeekTraceModel>.Instance.IconType;
			if (iconType != ETraceTracingImageType.Type1)
			{
				if (iconType == ETraceTracingImageType.Type2)
				{
					resourceId = "TraceClawType2Icon";
					resourceId2 = "TraceClawType2Bg";
				}
			}
			else
			{
				resourceId = "TraceClawType1Icon";
				resourceId2 = "TraceClawType1Bg";
			}
			base.SetTextureByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId), base.GetTexture(2), null, null);
			base.SetTextureByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId2), base.GetTexture(3), null, null);
		}

		// Token: 0x0200CA06 RID: 51718
		public enum EComponentType
		{
			// Token: 0x0403E126 RID: 254246
			Line1Texture,
			// Token: 0x0403E127 RID: 254247
			Line2Texture,
			// Token: 0x0403E128 RID: 254248
			IconTexture,
			// Token: 0x0403E129 RID: 254249
			BackgroundTexture
		}
	}
}
