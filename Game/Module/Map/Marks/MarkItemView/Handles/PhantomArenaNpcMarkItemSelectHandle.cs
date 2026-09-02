using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Mark.Component;
using CSharpScript.Game.Module.Map.Marks.MarkItemView.Components;
using CSharpScript.Game.Module.Map.Marks.MarkItemView.Components.SubComponents;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles
{
	// Token: 0x0200589D RID: 22685
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaNpcMarkItemSelectHandle : MarkItemSelectHandle
	{
		// Token: 0x06039A6E RID: 236142 RVA: 0x00E9ECF7 File Offset: 0x00E9CEF7
		public PhantomArenaNpcMarkItemSelectHandle(IMarkItemComponentContext context) : base(context)
		{
		}

		// Token: 0x06039A6F RID: 236143 RVA: 0x00E9ED00 File Offset: 0x00E9CF00
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		protected override UniTask<MarkSelectComponent> LoadComponentAsync()
		{
			PhantomArenaNpcMarkItemSelectHandle.<LoadComponentAsync>d__3 <LoadComponentAsync>d__;
			<LoadComponentAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<MarkSelectComponent>.Create();
			<LoadComponentAsync>d__.<>4__this = this;
			<LoadComponentAsync>d__.<>1__state = -1;
			<LoadComponentAsync>d__.<>t__builder.Start<PhantomArenaNpcMarkItemSelectHandle.<LoadComponentAsync>d__3>(ref <LoadComponentAsync>d__);
			return <LoadComponentAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039A70 RID: 236144 RVA: 0x00E9ED44 File Offset: 0x00E9CF44
		protected override MarkSelectComponent GetOrCreateComponent()
		{
			MapModel instance = ModelBase<MapModel>.Instance;
			if (instance != null && instance.IsExtraUiMarkType(EMapType.WorldMap, EMarkType.PhantomArenaNpc))
			{
				if (this.PhantomArenaSelectComponent == null)
				{
					this.LoadComponentAsync().ContinueWith(delegate(MarkSelectComponent _)
					{
						base.ApplyModified();
					});
				}
				this.ComponentInternal = this.PhantomArenaSelectComponent;
			}
			else
			{
				if (this.NormalComponent == null)
				{
					this.LoadComponentAsync().ContinueWith(delegate(MarkSelectComponent _)
					{
						base.ApplyModified();
					});
				}
				this.ComponentInternal = this.NormalComponent;
			}
			return this.ComponentInternal;
		}

		// Token: 0x06039A71 RID: 236145 RVA: 0x00E9EDC8 File Offset: 0x00E9CFC8
		protected override void OnApplyModified()
		{
			MarkViewLifeCircleComponent viewLifeCircle = this.Context.MarkItemEntity.ViewLifeCircle;
			if (viewLifeCircle.IsChildViewStateDirty(EMarkViewComponentType.Select))
			{
				MarkSelectComponent orCreateComponent = this.GetOrCreateComponent();
				if (!this.IsComponentValid(orCreateComponent))
				{
					return;
				}
				bool active = viewLifeCircle.IsChildViewVisible(EMarkViewComponentType.Select, false);
				viewLifeCircle.SetChildViewVisibleClean(EMarkViewComponentType.Select);
				MarkItemComponentHandle<MarkSelectComponent>.SetComponentActive(orCreateComponent, active);
			}
		}

		// Token: 0x04020AEC RID: 133868
		[Nullable(2)]
		private MarkSelectComponent NormalComponent;

		// Token: 0x04020AED RID: 133869
		[Nullable(2)]
		private PhantomArenaNpcMarkSelectComponent PhantomArenaSelectComponent;
	}
}
