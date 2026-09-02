using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005163 RID: 20835
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PhantomElementItem : GridProxyAbstract<ElementInfo>
	{
		// Token: 0x060359E8 RID: 219624 RVA: 0x00D77BF8 File Offset: 0x00D75DF8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060359E9 RID: 219625 RVA: 0x00D77C84 File Offset: 0x00D75E84
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomElementItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomElementItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060359EA RID: 219626 RVA: 0x00D77CC7 File Offset: 0x00D75EC7
		public override void Refresh(ElementInfo data, bool isSelected, int gridIndex)
		{
			this.Update(data);
		}

		// Token: 0x060359EB RID: 219627 RVA: 0x00D77CD0 File Offset: 0x00D75ED0
		public void Update(ElementInfo elementInfo)
		{
			this.ElementInfo = elementInfo;
			this.ElementItem.Update(this.ElementInfo);
			this.RefreshPanel(null);
		}

		// Token: 0x060359EC RID: 219628 RVA: 0x00D77CF4 File Offset: 0x00D75EF4
		[NullableContext(2)]
		public bool RefreshPanel(Dictionary<int, int> elementDict = null)
		{
			ValueTuple<bool, bool, int, int, int> finishInfo = this.GetFinishInfo(elementDict);
			bool item = finishInfo.Item1;
			bool item2 = finishInfo.Item2;
			int item3 = finishInfo.Item3;
			int item4 = finishInfo.Item4;
			int item5 = finishInfo.Item5;
			base.GetSprite(2).SetUIActive(item);
			base.GetText(1).SetUIActive(!item);
			base.GetItem(0).SetUIActive(!item);
			string textStringId;
			if (item)
			{
				textStringId = "RoguelikeView_Finish_Text";
			}
			else if (item2)
			{
				textStringId = "RoguelikeView_Preview_Text";
			}
			else
			{
				textStringId = "RoguelikeView_NotFinish_Text";
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, new <>z__ReadOnlyArray<object>(new object[]
			{
				item3,
				item4,
				item5
			}));
			return item;
		}

		// Token: 0x060359ED RID: 219629 RVA: 0x00D77DB8 File Offset: 0x00D75FB8
		[NullableContext(0)]
		private ValueTuple<bool, bool, int, int, int> GetFinishInfo([Nullable(2)] Dictionary<int, int> elementDict = null)
		{
			Dictionary<int, int> elementDict2 = ModelBase<RoguelikeModel>.Instance.RogueInfo.ElementDict;
			int count = this.ElementInfo.Count;
			int num2;
			int num = elementDict2.TryGetValue(this.ElementInfo.ElementId, out num2) ? num2 : 0;
			int num3;
			num += (elementDict2.TryGetValue(7, out num3) ? num3 : 0);
			int num4 = 0;
			bool item = false;
			if (elementDict != null)
			{
				int num5;
				int num6;
				num4 = (elementDict.TryGetValue(this.ElementInfo.ElementId, out num5) ? num5 : 0) + (elementDict.TryGetValue(7, out num6) ? num6 : 0);
				if (this.ElementInfo.ElementId == 9)
				{
					foreach (int num7 in elementDict.Values)
					{
						num4 += num7;
					}
				}
				if (num4 > 0)
				{
					item = true;
				}
			}
			return new ValueTuple<bool, bool, int, int, int>(num + num4 >= count, item, num, count, num4);
		}

		// Token: 0x0401ECB6 RID: 126134
		private ElementInfo ElementInfo;

		// Token: 0x0401ECB7 RID: 126135
		private ElementItem ElementItem;

		// Token: 0x0200B110 RID: 45328
		[NullableContext(0)]
		private class EPhantomElementItemCom
		{
			// Token: 0x04036EC1 RID: 224961
			public const int ElementItem = 0;

			// Token: 0x04036EC2 RID: 224962
			public const int NumText = 1;

			// Token: 0x04036EC3 RID: 224963
			public const int FinishSprite = 2;
		}
	}
}
