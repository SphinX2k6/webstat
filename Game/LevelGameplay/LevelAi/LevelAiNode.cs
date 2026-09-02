using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelAi
{
	// Token: 0x02006E11 RID: 28177
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelAiNode : IStaticVariableResetter
	{
		// Token: 0x06044680 RID: 280192 RVA: 0x011C5169 File Offset: 0x011C3369
		static LevelAiNode()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(LevelAiNode.CreateStaticDefaultValue), new Action(LevelAiNode.ResetStaticDefaultValue));
		}

		// Token: 0x06044681 RID: 280193 RVA: 0x011C5188 File Offset: 0x011C3388
		public virtual void Serialize(CharacterPlanComponent ownerComponent, CreatureDataComponent creatureDataComp, string description, [Nullable(2)] ActionParams @params = null)
		{
			this.CharacterPlanComp = ownerComponent;
			this.CreatureDataComp = creatureDataComp;
			this.Description = description;
		}

		// Token: 0x1700A363 RID: 41827
		// (get) Token: 0x06044682 RID: 280194 RVA: 0x011C519F File Offset: 0x011C339F
		public CreatureDataComponent CreatureDataComponent
		{
			get
			{
				return this.CreatureDataComp;
			}
		}

		// Token: 0x1700A364 RID: 41828
		// (get) Token: 0x06044683 RID: 280195 RVA: 0x011C51A7 File Offset: 0x011C33A7
		public CharacterPlanComponent CharacterPlanComponent
		{
			get
			{
				return this.CharacterPlanComp;
			}
		}

		// Token: 0x06044684 RID: 280196 RVA: 0x011C51AF File Offset: 0x011C33AF
		public void PrintDescription(string reason, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
		}

		// Token: 0x06044685 RID: 280197 RVA: 0x011C51B1 File Offset: 0x011C33B1
		public static void CreateStaticDefaultValue()
		{
		}

		// Token: 0x06044686 RID: 280198 RVA: 0x011C51B3 File Offset: 0x011C33B3
		public static void ResetStaticDefaultValue()
		{
			LevelAiNode.UidGenerator = 0;
		}

		// Token: 0x04026124 RID: 155940
		private static int UidGenerator;

		// Token: 0x04026125 RID: 155941
		private readonly int Uid = ++LevelAiNode.UidGenerator;

		// Token: 0x04026126 RID: 155942
		[Nullable(2)]
		private CreatureDataComponent CreatureDataComp;

		// Token: 0x04026127 RID: 155943
		[Nullable(2)]
		private CharacterPlanComponent CharacterPlanComp;

		// Token: 0x04026128 RID: 155944
		protected string Description = "";
	}
}
