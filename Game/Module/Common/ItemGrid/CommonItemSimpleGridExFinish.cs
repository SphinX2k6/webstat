using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Common.ItemGrid
{
	// Token: 0x02005E6F RID: 24175
	public class CommonItemSimpleGridExFinish : CommonItemSimpleGrid
	{
		// Token: 0x0603CCD6 RID: 249046 RVA: 0x00F702E7 File Offset: 0x00F6E4E7
		[NullableContext(1)]
		public CommonItemSimpleGridExFinish(AActor commonItemActor)
		{
			if (commonItemActor == null)
			{
				this.CreateThenShowByActor(commonItemActor);
			}
		}

		// Token: 0x0603CCD7 RID: 249047 RVA: 0x00F702F9 File Offset: 0x00F6E4F9
		protected override void OnRegisterComponent()
		{
			base.OnRegisterComponent();
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(5, typeof(UUIItem)));
		}

		// Token: 0x0603CCD8 RID: 249048 RVA: 0x00F7031C File Offset: 0x00F6E51C
		public void SetReceived(bool received)
		{
			base.GetItem(5).SetUIActive(received);
		}

		// Token: 0x0200BE7F RID: 48767
		private enum EChildComponentType
		{
			// Token: 0x0403AA82 RID: 240258
			FinishedItem = 5
		}
	}
}
