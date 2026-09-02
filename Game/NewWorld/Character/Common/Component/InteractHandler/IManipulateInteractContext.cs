using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.NewWorld.SceneItem;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.InteractHandler
{
	// Token: 0x02004948 RID: 18760
	[NullableContext(2)]
	public interface IManipulateInteractContext
	{
		// Token: 0x170083AB RID: 33707
		// (get) Token: 0x060310CF RID: 200911
		[Nullable(1)]
		BaseTagComponent TagComp { [NullableContext(1)] get; }

		// Token: 0x170083AC RID: 33708
		// (get) Token: 0x060310D0 RID: 200912
		[Nullable(1)]
		CharacterBuffComponent BuffComp { [NullableContext(1)] get; }

		// Token: 0x170083AD RID: 33709
		// (get) Token: 0x060310D1 RID: 200913
		[Nullable(1)]
		CharacterActorComponent ActorComp { [NullableContext(1)] get; }

		// Token: 0x170083AE RID: 33710
		// (get) Token: 0x060310D2 RID: 200914
		[Nullable(1)]
		CreatureDataComponent CreatureDataComp { [NullableContext(1)] get; }

		// Token: 0x170083AF RID: 33711
		// (get) Token: 0x060310D3 RID: 200915
		string EffectPath { get; }

		// Token: 0x170083B0 RID: 33712
		// (get) Token: 0x060310D4 RID: 200916
		SceneItemExploreInteractComponent ChooseTargetOnStartSkill { get; }

		// Token: 0x170083B1 RID: 33713
		// (get) Token: 0x060310D5 RID: 200917
		SceneItemExploreInteractComponent BestTargetInternal { get; }

		// Token: 0x170083B2 RID: 33714
		// (get) Token: 0x060310D6 RID: 200918
		bool CurrentPointLegal { get; }

		// Token: 0x170083B3 RID: 33715
		// (get) Token: 0x060310D7 RID: 200919
		// (set) Token: 0x060310D8 RID: 200920
		bool Interacting { get; set; }

		// Token: 0x170083B4 RID: 33716
		// (get) Token: 0x060310D9 RID: 200921
		// (set) Token: 0x060310DA RID: 200922
		SceneItemExploreInteractComponent SelectedTargetInternal { get; set; }

		// Token: 0x170083B5 RID: 33717
		// (get) Token: 0x060310DB RID: 200923
		// (set) Token: 0x060310DC RID: 200924
		long? CurBuffId { get; set; }

		// Token: 0x060310DD RID: 200925
		bool CheckBeforeInteract(EExploreSkillInteractType type);

		// Token: 0x060310DE RID: 200926
		void RequestInteractAction();

		// Token: 0x060310DF RID: 200927
		void SpawnEffect();
	}
}
