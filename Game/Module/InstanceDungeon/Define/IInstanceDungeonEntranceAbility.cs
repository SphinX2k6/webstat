using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.InstanceDungeon.Define
{
	// Token: 0x02005C0A RID: 23562
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class IInstanceDungeonEntranceAbility : UiPanelBase
	{
		// Token: 0x170097B4 RID: 38836
		// (get) Token: 0x0603B998 RID: 244120
		public abstract string ResourceId { get; }

		// Token: 0x0603B999 RID: 244121
		public abstract UniTask RefreshExternalAsync();

		// Token: 0x0603B99A RID: 244122 RVA: 0x00F1B90F File Offset: 0x00F19B0F
		public virtual void RefreshOnTick()
		{
		}
	}
}
