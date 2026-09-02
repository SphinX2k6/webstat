using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Mark.Component;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.Marks.MarkItemView.Components;
using CSharpScript.Game.Module.Morale.Data;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles
{
	// Token: 0x02005892 RID: 22674
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MarkItemChildIconHandle : MarkItemComponentHandle<MarkChildIconComponent>
	{
		// Token: 0x06039A1A RID: 236058 RVA: 0x00E9DD46 File Offset: 0x00E9BF46
		public MarkItemChildIconHandle(IMarkItemComponentContext context) : base(context)
		{
		}

		// Token: 0x06039A1B RID: 236059 RVA: 0x00E9DD50 File Offset: 0x00E9BF50
		protected override void OnUpdate()
		{
			MarkItem markItem = this.Context.MarkItem;
			if (markItem.ShowSecondaryUiMultiMapIcon())
			{
				base.SetVisible(true);
				this.Context.MarkItemEntity.Resource.ChildIconPath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(markItem.IsSelectThisFloor ? "SP_MarkMultiMapSelect" : "SP_MarkMultiMap");
				return;
			}
			if (this.CheckMoraleFlagBox())
			{
				base.SetVisible(true);
				return;
			}
			base.SetVisible(false);
		}

		// Token: 0x06039A1C RID: 236060 RVA: 0x00E9DDC4 File Offset: 0x00E9BFC4
		private bool CheckMoraleFlagBox()
		{
			MarkConfigComponent component = this.Context.MarkItemEntity.GetComponent<MarkConfigComponent>(EMapComponent.MarkConfig);
			if (component == null || component.RelativeSubType.GetValueOrDefault() != EMarkRelativeSubType.MoraleFlag)
			{
				return false;
			}
			MoraleAreaFlagData flagDataByMarkId = ModelBase<MoraleModel>.Instance.GetFlagDataByMarkId(component.MarkId.Value);
			if (flagDataByMarkId == null || !flagDataByMarkId.HasBoxCanGet())
			{
				return false;
			}
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_MarkGift");
			this.Context.MarkItemEntity.Resource.ChildIconPath = resourcePath;
			return true;
		}

		// Token: 0x06039A1D RID: 236061 RVA: 0x00E9DE4C File Offset: 0x00E9C04C
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		protected override UniTask<MarkChildIconComponent> LoadComponentAsync()
		{
			MarkItemChildIconHandle.<LoadComponentAsync>d__3 <LoadComponentAsync>d__;
			<LoadComponentAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<MarkChildIconComponent>.Create();
			<LoadComponentAsync>d__.<>4__this = this;
			<LoadComponentAsync>d__.<>1__state = -1;
			<LoadComponentAsync>d__.<>t__builder.Start<MarkItemChildIconHandle.<LoadComponentAsync>d__3>(ref <LoadComponentAsync>d__);
			return <LoadComponentAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039A1E RID: 236062 RVA: 0x00E9DE8F File Offset: 0x00E9C08F
		protected override MarkChildIconComponent GetOrCreateComponent()
		{
			if (this.ComponentInternal == null)
			{
				this.LoadComponentAsync().ContinueWith(delegate(MarkChildIconComponent _)
				{
					MarkChildIconComponent componentInternal = this.ComponentInternal;
					if (componentInternal != null)
					{
						UUIItem rootItem = componentInternal.GetRootItem();
						if (rootItem != null)
						{
							FVectorDouble fvectorDouble = this.Context.MarkItem.CornerScaleVector.ToUeVector(false);
							FVector fvector = fvectorDouble;
							rootItem.SetUIRelativeScale3D(fvector);
						}
					}
					base.ApplyModified();
				});
			}
			return this.ComponentInternal;
		}

		// Token: 0x06039A1F RID: 236063 RVA: 0x00E9DEB7 File Offset: 0x00E9C0B7
		protected override void OnSetVisible(bool active)
		{
			this.Context.MarkItemEntity.ViewLifeCircle.SetChildViewVisibility(EMarkViewComponentType.ChildIcon, active);
		}

		// Token: 0x06039A20 RID: 236064 RVA: 0x00E9DED0 File Offset: 0x00E9C0D0
		protected override void OnApplyModified()
		{
			MarkItemEntity markItemEntity = this.Context.MarkItemEntity;
			MarkViewLifeCircleComponent viewLifeCircle = markItemEntity.ViewLifeCircle;
			bool flag = viewLifeCircle.IsChildViewVisible(EMarkViewComponentType.ChildIcon, false);
			MarkResourceComponent resource = markItemEntity.Resource;
			if (flag && resource.IsChildIconPathDirty)
			{
				MarkChildIconComponent orCreateComponent = this.GetOrCreateComponent();
				if (!this.IsComponentValid(orCreateComponent))
				{
					return;
				}
				orCreateComponent.Icon = resource.ChildIconPath;
			}
			if (viewLifeCircle.IsChildViewStateDirty(EMarkViewComponentType.ChildIcon))
			{
				MarkChildIconComponent orCreateComponent2 = this.GetOrCreateComponent();
				if (!this.IsComponentValid(orCreateComponent2))
				{
					return;
				}
				viewLifeCircle.SetChildViewVisibleClean(EMarkViewComponentType.ChildIcon);
				MarkItemComponentHandle<MarkChildIconComponent>.SetComponentActive(orCreateComponent2, flag);
			}
		}
	}
}
