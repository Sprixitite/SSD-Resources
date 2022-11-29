project('MonoWinformsSoftwareRenderer', 'cs')

src = []
subdir('src')

add_global_arguments(['/r:System.Windows.Forms.dll', '/r:System.Drawing.dll'], language: ['cs'])

executable(
    'MonoWinformsSoftwareRenderer', src,
    gui_app: true,
)