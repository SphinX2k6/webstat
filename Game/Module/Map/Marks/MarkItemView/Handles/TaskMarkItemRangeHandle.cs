using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItemView.Components;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles
{
	// Token: 0x0200589E RID: 22686
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TaskMarkItemRangeHandle : MarkItemRangeHandle<MarkRangeImageComponent>
	{
		// Token: 0x06039A74 RID: 236148 RVA: 0x00E9EE27 File Offset: 0x00E9D027
		public TaskMarkItemRangeHandle(IMarkItemComponentContext context) : base(context)
		{
		}

		// Token: 0x06039A75 RID: 236149 RVA: 0x00E9EE30 File Offset: 0x00E9D030
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		protected override UniTask<MarkRangeImageComponent> LoadComponentAsync()
		{
			TaskMarkItemRangeHandle.<LoadComponentAsync>d__1 <LoadComponentAsync>d__;
			<LoadComponentAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<MarkRangeImageComponent>.Create();
			<LoadComponentAsync>d__.<>4__this = this;
			<LoadComponentAsync>d__.<>1__state = -1;
			<LoadComponentAsync>d__.<>t__builder.Start<TaskMarkItemRangeHandle.<LoadComponentAsync>d__1>(ref <LoadComponentAsync>d__);
			return <LoadComponentAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039A76 RID: 236150 RVA: 0x00E9EE74 File Offset: 0x00E9D074
		protected override void OnResetRangeComponent(MarkRangeImageComponent rangeComponent)
		{
			base.OnResetRangeComponent(rangeComponent);
			Vector2D vector2D = Vector2D.Create(this.Context.MarkItem.UiPosition.X, this.Context.MarkItem.UiPosition.Y);
			rangeComponent.GetRootItem().SetAnchorOffset(vector2D.ToUeVector2D(false));
			rangeComponent.GetRootItem().SetAsFirstHierarchy();
		}
	}
}
