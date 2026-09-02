using System;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine
{
	// Token: 0x02006ECE RID: 28366
	public class DollGrabMachineClawDirection : IClear
	{
		// Token: 0x1700A3F9 RID: 41977
		// (get) Token: 0x06044BD6 RID: 281558 RVA: 0x011DE29A File Offset: 0x011DC49A
		// (set) Token: 0x06044BD7 RID: 281559 RVA: 0x011DE2A2 File Offset: 0x011DC4A2
		public float X { get; set; }

		// Token: 0x1700A3FA RID: 41978
		// (get) Token: 0x06044BD8 RID: 281560 RVA: 0x011DE2AB File Offset: 0x011DC4AB
		// (set) Token: 0x06044BD9 RID: 281561 RVA: 0x011DE2B3 File Offset: 0x011DC4B3
		public float Y { get; set; }

		// Token: 0x06044BDA RID: 281562 RVA: 0x011DE2BC File Offset: 0x011DC4BC
		public DollGrabMachineClawDirection(float x = 0f, float y = 0f)
		{
			this.X = x;
			this.Y = y;
		}

		// Token: 0x06044BDB RID: 281563 RVA: 0x011DE2D2 File Offset: 0x011DC4D2
		public bool ClearObject()
		{
			return true;
		}
	}
}
