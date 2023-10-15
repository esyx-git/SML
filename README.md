# Simple Mantella Launcher (SML)

SML is a simple and convenient launcher for Skyrim that is designed to automatically open, monitor, and close Mod Organizer, Mantella, and xVASynth. (There is also support for a self-hosted LLM and Herika as well.)
It eliminates the need to open and close each program individually, providing a seamless experience for you, the user.

## Getting Started

Before using SML, you must specify the path to each program within the provided Config.xml file. Follow the steps below to set up the launcher correctly:

1. Open the Config.xml file using a text editor.
2. Locate the `<Program>` tags for each required program (Mod Organizer, Mantella, and xVASynth).
3. Update the path within each `<Program>` tag to point to the respective program's executable file on your computer.
   - For example: `<ModOrganizer>C:\Path\To\ModOrganizer.exe</ModOrganizer>`
4. If you are using LLM and/or Herika, set the respected <UseProgram> tag to true and set the correct path, otherwise ignore this step. (LLM and Herika paths can be left alone if their tags are set to false.)
   - For example: `<LLM>true</LLM>`
5. Save the Config.xml file.

**Important:** Make sure that both the Config.xml file and the SML executable file are located in the same folder.

## Running the Launcher

To run SML, simply execute the launcher's executable file. 

Optional steps for convenience:

1. Create a shortcut to the launcher executable file for easy access.
2. Customize the shortcut's icon to differentiate it from other shortcuts.
3. Optionally, pin the shortcut to your start menu for quicker access.
4. Profit?

## Closing the Programs

To close all opened programs, simply close Mod Organizer. SML will automatically close all associated programs (Mantella, and xVASynth) as well.

**Note:** SML will only open and close additional programs (LLM and Herika) if the respective options in the Config.xml file are set to true.

## Troubleshooting

If you encounter any issues or have questions, please feel free to reach out for support.

**Note:** The launcher may not close associated programs properly if they are manually opened and closed, but this should not have any catastrophic results other than a mild inconveniece.

## License

This project is licensed under the [GPL v3.0 License](https://opensource.org/license/gpl-3-0/) - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Mantella, Herika, xVASynth, and Mod Organizer developers for all of their fantastic work.
