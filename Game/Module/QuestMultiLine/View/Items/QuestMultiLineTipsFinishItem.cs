using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.QuestMultiLine.QuestMultiLineData;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuestMultiLine.View.Items
{
	// Token: 0x0200533E RID: 21310
	public class QuestMultiLineTipsFinishItem : UiPanelBase
	{
		// Token: 0x060365C9 RID: 222665 RVA: 0x00DB4AE8 File Offset: 0x00DB2CE8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}

		// Token: 0x060365CA RID: 222666 RVA: 0x00DB4B7C File Offset: 0x00DB2D7C
		[NullableContext(1)]
		public void RefreshHead(QuestMultiLineComponentData componentData)
		{
			this.ComponentData = componentData;
			base.SetTextureByPath(QuestMultiLineUtils.GetComponentIconTexture(this.ComponentData), base.GetTexture(0), null, null);
		}

		// Token: 0x0401F43B RID: 128059
		[Nullable(2)]
		private QuestMultiLineComponentData ComponentData;
	}
}
