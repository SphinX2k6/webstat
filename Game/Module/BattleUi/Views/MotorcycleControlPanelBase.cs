using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006080 RID: 24704
	public class MotorcycleControlPanelBase : BattleVisibleChildView
	{
		// Token: 0x0603E4E6 RID: 255206 RVA: 0x00FE8C37 File Offset: 0x00FE6E37
		public virtual void Tick(float delta)
		{
		}

		// Token: 0x0603E4E7 RID: 255207 RVA: 0x00FE8C3C File Offset: 0x00FE6E3C
		[NullableContext(1)]
		public UniTask Init(UUIItem parentItem, string resourceId)
		{
			MotorcycleControlPanelBase.<Init>d__1 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.parentItem = parentItem;
			<Init>d__.resourceId = resourceId;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MotorcycleControlPanelBase.<Init>d__1>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0603E4E8 RID: 255208 RVA: 0x00FE8C8F File Offset: 0x00FE6E8F
		protected override void OnBeforeDestroy()
		{
			base.OnBeforeDestroy();
			this.Reset();
		}
	}
}
