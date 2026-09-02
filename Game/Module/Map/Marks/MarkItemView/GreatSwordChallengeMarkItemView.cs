using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItem;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x02005870 RID: 22640
	[NullableContext(1)]
	[Nullable(0)]
	public class GreatSwordChallengeMarkItemView : ConfigMarkItemView
	{
		// Token: 0x06039906 RID: 235782 RVA: 0x00E9AD2E File Offset: 0x00E98F2E
		public GreatSwordChallengeMarkItemView(GreatSwordChallengeMarkItem holder) : base(holder)
		{
			this.GreatSwordChallengeMarkItem = holder;
		}

		// Token: 0x06039907 RID: 235783 RVA: 0x00E9AD3E File Offset: 0x00E98F3E
		protected override void OnViewRefresh()
		{
			this.GreatSwordChallengeMarkItem.UpdateIconPath();
			this.OnIconPathChanged(this.Holder.IconPath);
		}

		// Token: 0x06039908 RID: 235784 RVA: 0x00E9AD5C File Offset: 0x00E98F5C
		public override void RegisterEvents()
		{
		}

		// Token: 0x06039909 RID: 235785 RVA: 0x00E9AD5E File Offset: 0x00E98F5E
		public override void UnRegisterEvents()
		{
		}

		// Token: 0x0603990A RID: 235786 RVA: 0x00E9AD60 File Offset: 0x00E98F60
		protected override void OnSafeUpdate(Vector playerLocation, bool bDragging = false, bool bIsScale = false)
		{
			this.GreatSwordChallengeMarkItem.UpdateIconPath();
			this.OnIconPathChanged(this.Holder.IconPath);
		}

		// Token: 0x04020AB8 RID: 133816
		[Nullable(2)]
		private readonly GreatSwordChallengeMarkItem GreatSwordChallengeMarkItem;
	}
}
