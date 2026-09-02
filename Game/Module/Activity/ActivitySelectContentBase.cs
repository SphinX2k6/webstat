using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity
{
	// Token: 0x020061D5 RID: 25045
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivitySelectContentBase : UiPanelBase, IDynamicScrollBaseItem<ActivityBaseData>
	{
		// Token: 0x0603F337 RID: 258871 RVA: 0x010399F8 File Offset: 0x01037BF8
		public UniTask Init(UUIItem actor)
		{
			ActivitySelectContentBase.<Init>d__0 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<ActivitySelectContentBase.<Init>d__0>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0603F338 RID: 258872 RVA: 0x01039A43 File Offset: 0x01037C43
		public void ClearItem()
		{
		}

		// Token: 0x0603F339 RID: 258873 RVA: 0x01039A45 File Offset: 0x01037C45
		public FVector2D GetItemSize(ActivityBaseData data)
		{
			Vector2D vector2D = Vector2D.Create();
			vector2D.Set((double)this.RootItem.Width, (double)this.RootItem.Height);
			return vector2D.ToUeVector2D(false);
		}
	}
}
