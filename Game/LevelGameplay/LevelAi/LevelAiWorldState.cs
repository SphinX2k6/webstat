using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelAi
{
	// Token: 0x02006E1F RID: 28191
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelAiWorldState : IStaticVariableResetter
	{
		// Token: 0x06044703 RID: 280323 RVA: 0x011C7343 File Offset: 0x011C5543
		static LevelAiWorldState()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(LevelAiWorldState.CreateStaticDefaultValue), new Action(LevelAiWorldState.ResetStaticDefaultValue));
		}

		// Token: 0x06044704 RID: 280324 RVA: 0x011C7362 File Offset: 0x011C5562
		public void SetBooleanWorldState(string key, bool value)
		{
			this.BooleanWorldState[key] = value;
		}

		// Token: 0x06044705 RID: 280325 RVA: 0x011C7371 File Offset: 0x011C5571
		public void SetIntWorldState(string key, long value)
		{
			this.IntWorldState[key] = value;
		}

		// Token: 0x06044706 RID: 280326 RVA: 0x011C7380 File Offset: 0x011C5580
		public void RemoveBooleanWorldState(string key)
		{
			this.BooleanWorldState.Remove(key);
		}

		// Token: 0x06044707 RID: 280327 RVA: 0x011C738F File Offset: 0x011C558F
		public void RemoveIntWorldState(string key)
		{
			this.IntWorldState.Remove(key);
		}

		// Token: 0x06044708 RID: 280328 RVA: 0x011C739E File Offset: 0x011C559E
		public bool GetBooleanWorldState(string key)
		{
			return this.BooleanWorldState[key];
		}

		// Token: 0x06044709 RID: 280329 RVA: 0x011C73AC File Offset: 0x011C55AC
		public long GetIntWorldState(string key)
		{
			return this.IntWorldState[key];
		}

		// Token: 0x0604470A RID: 280330 RVA: 0x011C73BC File Offset: 0x011C55BC
		public LevelAiWorldState MakeCopy()
		{
			LevelAiWorldState levelAiWorldState = new LevelAiWorldState();
			foreach (KeyValuePair<string, bool> keyValuePair in this.BooleanWorldState)
			{
				levelAiWorldState.BooleanWorldState[keyValuePair.Key] = keyValuePair.Value;
			}
			foreach (KeyValuePair<string, long> keyValuePair2 in this.IntWorldState)
			{
				levelAiWorldState.IntWorldState[keyValuePair2.Key] = keyValuePair2.Value;
			}
			return levelAiWorldState;
		}

		// Token: 0x0604470B RID: 280331 RVA: 0x011C7480 File Offset: 0x011C5680
		public static void CreateStaticDefaultValue()
		{
			LevelAiWorldState.UidGenerator = 0;
		}

		// Token: 0x0604470C RID: 280332 RVA: 0x011C7488 File Offset: 0x011C5688
		public static void ResetStaticDefaultValue()
		{
			LevelAiWorldState.UidGenerator = 0;
		}

		// Token: 0x04026162 RID: 156002
		private static int UidGenerator;

		// Token: 0x04026163 RID: 156003
		public readonly int Uid = ++LevelAiWorldState.UidGenerator;

		// Token: 0x04026164 RID: 156004
		public Dictionary<string, bool> BooleanWorldState = new Dictionary<string, bool>();

		// Token: 0x04026165 RID: 156005
		public Dictionary<string, long> IntWorldState = new Dictionary<string, long>();
	}
}
