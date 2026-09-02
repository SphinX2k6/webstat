using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E52 RID: 20050
	public class TrapDefenseTalentTreeDetailPanel : UiPanelBase
	{
		// Token: 0x06033D04 RID: 212228 RVA: 0x00CF45A0 File Offset: 0x00CF27A0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033D05 RID: 212229 RVA: 0x00CF4690 File Offset: 0x00CF2890
		public void Refresh()
		{
			TrapDefenseTalentTreeNodeData selectedNode = ModelBase<TrapDefenseModel>.Instance.ViewModelTalentTree.SelectedNode;
			if (selectedNode == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), selectedNode.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), TrapDefenseDefine.trapDefenseTalentTreeTypeNames[selectedNode.Type], Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), selectedNode.Desc, Array.Empty<object>());
			this.SetSpriteByPath(selectedNode.IconBig, base.GetSprite(2), false, null, null);
		}

		// Token: 0x0200ADEF RID: 44527
		private class EComponentDefine
		{
			// Token: 0x0403602E RID: 221230
			public const int TextName = 0;

			// Token: 0x0403602F RID: 221231
			public const int TextType = 1;

			// Token: 0x04036030 RID: 221232
			public const int SpriteIcon = 2;

			// Token: 0x04036031 RID: 221233
			public const int Layout = 3;

			// Token: 0x04036032 RID: 221234
			public const int ItemDesc = 4;

			// Token: 0x04036033 RID: 221235
			public const int TextDesc = 5;
		}
	}
}
