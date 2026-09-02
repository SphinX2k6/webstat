using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200510D RID: 20749
	[NullableContext(2)]
	[Nullable(0)]
	public class ElementInfo
	{
		// Token: 0x06035762 RID: 218978 RVA: 0x00D6B330 File Offset: 0x00D69530
		public ElementInfo(int elementId, int count, string name = null)
		{
			this.ElementId = elementId;
			this.Count = count;
			this.Name = name;
			this.IsPreview = false;
		}

		// Token: 0x0401EB76 RID: 125814
		public int ElementId;

		// Token: 0x0401EB77 RID: 125815
		public int Count;

		// Token: 0x0401EB78 RID: 125816
		public string Name;

		// Token: 0x0401EB79 RID: 125817
		public bool IsPreview;
	}
}
