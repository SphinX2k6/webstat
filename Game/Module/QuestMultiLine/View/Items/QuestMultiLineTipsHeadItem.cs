using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.QuestMultiLine.QuestMultiLineData;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuestMultiLine.View.Items
{
	// Token: 0x02005340 RID: 21312
	public class QuestMultiLineTipsHeadItem : UiPanelBase
	{
		// Token: 0x060365CC RID: 222668 RVA: 0x00DB4BBC File Offset: 0x00DB2DBC
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

		// Token: 0x060365CD RID: 222669 RVA: 0x00DB4C50 File Offset: 0x00DB2E50
		[NullableContext(1)]
		public void RefreshHead(QuestMultiLineComponentData componentData)
		{
			this.ComponentData = componentData;
			base.SetTextureByPath(QuestMultiLineUtils.GetComponentIconTexture(this.ComponentData), base.GetTexture(0), null, null);
		}

		// Token: 0x0401F442 RID: 128066
		[Nullable(2)]
		private QuestMultiLineComponentData ComponentData;
	}
}
