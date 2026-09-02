using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks.MarkItemView.Components;
using CSharpScript.Game.Module.WorldMap;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles
{
	// Token: 0x0200588C RID: 22668
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class EnrichmentAreaItemRangeHandle : MarkItemRangeHandle<MarkBlueRangeImageComponent>
	{
		// Token: 0x060399E8 RID: 236008 RVA: 0x00E9DA31 File Offset: 0x00E9BC31
		public EnrichmentAreaItemRangeHandle(IMarkItemComponentContext context) : base(context)
		{
		}

		// Token: 0x060399E9 RID: 236009 RVA: 0x00E9DA3C File Offset: 0x00E9BC3C
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		protected override UniTask<MarkBlueRangeImageComponent> LoadComponentAsync()
		{
			EnrichmentAreaItemRangeHandle.<LoadComponentAsync>d__1 <LoadComponentAsync>d__;
			<LoadComponentAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<MarkBlueRangeImageComponent>.Create();
			<LoadComponentAsync>d__.<>4__this = this;
			<LoadComponentAsync>d__.<>1__state = -1;
			<LoadComponentAsync>d__.<>t__builder.Start<EnrichmentAreaItemRangeHandle.<LoadComponentAsync>d__1>(ref <LoadComponentAsync>d__);
			return <LoadComponentAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060399EA RID: 236010 RVA: 0x00E9DA7F File Offset: 0x00E9BC7F
		protected override MarkBlueRangeImageComponent GetOrCreateComponent()
		{
			if (this.ComponentInternal == null)
			{
				this.LoadComponentAsync().ContinueWith(delegate(MarkBlueRangeImageComponent _)
				{
					base.ApplyModified();
				});
			}
			return this.ComponentInternal;
		}

		// Token: 0x060399EB RID: 236011 RVA: 0x00E9DAA8 File Offset: 0x00E9BCA8
		protected override void OnResetRangeComponent(MarkRangeImageComponent rangeComponent)
		{
			EMarkType markType = this.Context.MarkItemEntity.GamePlay.MarkType;
			Singleton<EventSystem>.Instance.Emit<EMarkType, EMarkPriorityType>(EEventName.TakeMarkComponentExitContainer, markType, EMarkPriorityType.OthersLevel);
			MarkBlueRangeImageComponent componentInternal = this.ComponentInternal;
			UUIItem uuiitem = (componentInternal != null) ? componentInternal.GetRootItem() : null;
			if (uuiitem != null)
			{
				Singleton<EventSystem>.Instance.Emit<UUIItem, EMarkType, EMarkPriorityType>(EEventName.TakeMarkComponentEnterContainer, uuiitem, markType, EMarkPriorityType.OthersLevel);
			}
			base.OnResetRangeComponent(rangeComponent);
			Vector2D vector2D = Vector2D.Create(this.Context.MarkItem.UiPosition.X, this.Context.MarkItem.UiPosition.Y);
			UUIItem rootItem = rangeComponent.GetRootItem();
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetAnchorOffset(vector2D.ToUeVector2D(false));
		}

		// Token: 0x060399EC RID: 236012 RVA: 0x00E9DB54 File Offset: 0x00E9BD54
		protected override void DestroyComponent()
		{
			if (this.ComponentInternal != null)
			{
				this.ComponentInternal.RecycleToPool();
				Singleton<EventSystem>.Instance.Emit<EMarkType, EMarkPriorityType>(EEventName.TakeMarkComponentExitContainer, this.Context.MarkItemEntity.GamePlay.MarkType, EMarkPriorityType.OthersLevel);
				this.ComponentInternal = null;
			}
		}
	}
}
