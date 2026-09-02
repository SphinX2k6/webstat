using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.AdventureGuide.Views;

// Token: 0x02001750 RID: 5968
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class NewSoundDetectTabItemDungeonItem : SyncGridProxyAbstract<NewSoundDetectTabItemData>
{
	// Token: 0x0600A7DC RID: 42972 RVA: 0x002CAE95 File Offset: 0x002C9095
	protected override void OnStart()
	{
		this.TargetDungeonItem = new NewSoundDetectItem();
		this.TargetDungeonItem.CreateThenShowByActor(this.RootItem.GetOwner());
		this.TargetDungeonItem.SyncStart();
	}

	// Token: 0x0600A7DD RID: 42973 RVA: 0x002CAEC3 File Offset: 0x002C90C3
	public override void Refresh(NewSoundDetectTabItemData data)
	{
		if (data.Dungeon != null)
		{
			NewSoundDetectItem targetDungeonItem = this.TargetDungeonItem;
			if (targetDungeonItem == null)
			{
				return;
			}
			targetDungeonItem.Refresh(data.Dungeon, false, 0);
		}
	}

	// Token: 0x04004F3E RID: 20286
	[Nullable(2)]
	private NewSoundDetectItem TargetDungeonItem;
}
