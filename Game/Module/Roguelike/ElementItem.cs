using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200514D RID: 20813
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ElementItem : GridProxyAbstract<ElementInfo>
	{
		// Token: 0x06035928 RID: 219432 RVA: 0x00D73677 File Offset: 0x00D71877
		public override void Refresh(ElementInfo data, bool isSelected, int gridIndex)
		{
			this.Update(data);
		}

		// Token: 0x06035929 RID: 219433 RVA: 0x00D73680 File Offset: 0x00D71880
		public void Update(ElementInfo elementInfo)
		{
			this.ElementInfo = elementInfo;
			this.RefreshPanel();
		}

		// Token: 0x0603592A RID: 219434 RVA: 0x00D73690 File Offset: 0x00D71890
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603592B RID: 219435 RVA: 0x00D736FC File Offset: 0x00D718FC
		private void RefreshPanel()
		{
			if (!string.IsNullOrEmpty(this.ElementInfo.Name))
			{
				base.GetText(1).ShowTextNew(this.ElementInfo.Name);
			}
			else
			{
				UUIText text = base.GetText(1);
				UUIItem uuiitem = text;
				bool isPreview = this.ElementInfo.IsPreview;
				FColor? fcolor = new FColor?(text.changeColor);
				uuiitem.SetChangeColor(isPreview, fcolor);
				text.SetText(this.ElementInfo.Count.ToString(), true);
			}
			if (this.CommonElementItem == null)
			{
				this.CommonElementItem = new CommonElementItem();
				this.CommonElementItem.Update(this.ElementInfo.ElementId);
				this.CommonElementItem.CreateThenShowByActorAsync(base.GetItem(0).GetOwner()).ContinueWith(delegate()
				{
					CommonElementItem commonElementItem = this.CommonElementItem;
					if (commonElementItem == null)
					{
						return;
					}
					commonElementItem.RefreshPanel();
				});
				return;
			}
			this.CommonElementItem.Update(this.ElementInfo.ElementId);
			this.CommonElementItem.RefreshPanel();
		}

		// Token: 0x0401EC67 RID: 126055
		private ElementInfo ElementInfo;

		// Token: 0x0401EC68 RID: 126056
		private CommonElementItem CommonElementItem;

		// Token: 0x0200B0EE RID: 45294
		[NullableContext(0)]
		private class EElementItemCom
		{
			// Token: 0x04036E1D RID: 224797
			public const int CommonElementItem = 0;

			// Token: 0x04036E1E RID: 224798
			public const int CountText = 1;
		}
	}
}
