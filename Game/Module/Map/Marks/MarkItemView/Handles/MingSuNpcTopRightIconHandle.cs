using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark.Component;
using CSharpScript.Game.Module.MingSu;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles
{
	// Token: 0x0200589C RID: 22684
	public class MingSuNpcTopRightIconHandle : MarkItemTopRightIconHandle
	{
		// Token: 0x06039A6C RID: 236140 RVA: 0x00E9EBD6 File Offset: 0x00E9CDD6
		[NullableContext(1)]
		public MingSuNpcTopRightIconHandle(IMarkItemComponentContext context) : base(context)
		{
		}

		// Token: 0x06039A6D RID: 236141 RVA: 0x00E9EBE0 File Offset: 0x00E9CDE0
		protected override void OnUpdate()
		{
			MarkItemEntity markItemEntity = this.Context.MarkItemEntity;
			if (markItemEntity.GamePlay.IsDisable)
			{
				base.SetVisible(true);
				markItemEntity.Resource.TopRightIconPath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_MarkBlock");
				this.Context.SetSpriteByPathAction(markItemEntity.Resource.TopRightIconPath, this.Context.TopRightIconSprite, false, null, null);
				return;
			}
			MarkConfigComponent component = markItemEntity.GetComponent<MarkConfigComponent>(EMapComponent.MarkConfig);
			EMarkRelativeType value = component.RelativeType.Value;
			EMarkRelativeSubType value2 = component.RelativeSubType.Value;
			bool flag = false;
			if (value == EMarkRelativeType.LevelPlay && value2 == EMarkRelativeSubType.DarkCoastDelivery)
			{
				int value3 = component.RelativeId.Value;
				flag = (ModelBase<MingSuModel>.Instance.GetDarkCoastDeliveryDataByLevelPlayId(value3).GetDarkCoastDeliveryGuardState() == MingSuDefine.EDarkCoastDeliveryLevelDataState.Received);
				if (flag)
				{
					string topRightIconPath = markItemEntity.Resource.TopRightIconPath;
					this.Context.SetSpriteByPathAction(topRightIconPath, this.Context.TopRightIconSprite, false, null, null);
				}
			}
			base.SetVisible(flag);
		}
	}
}
